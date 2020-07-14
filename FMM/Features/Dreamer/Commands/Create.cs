using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;

namespace FMM.Features.Dreamer.Commands
{
    public class CreateCommand : IRequest
    {
        public DreamerRequest Dto { get; }

        public CreateCommand(DreamerRequest dto)
        {
            Dto = dto;
        }

        public class Handler : IRequestHandler<CreateCommand>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateCommand command, CancellationToken cancellationToken)
            {
                var dreamer = _mapper.Map<Persistent.Dreamer>(command.Dto);
                var dreamId = command.Dto.Dream?.Id;
                if (dreamId.HasValue)
                {
                    dreamer.Dream = _dbContext.Dreams.First(x => x.Id == dreamId);
                }

                await _dbContext.Dreamers.AddAsync(dreamer);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            public class CreateCommandValidator : AbstractValidator<CreateCommand>
            {
                public CreateCommandValidator()
                {
                    RuleFor(x => x.Dto.Dream).NotNull().NotEmpty();
                    RuleFor(x => x.Dto.FirstName).Length(1, 100).NotEmpty();
                    RuleFor(x => x.Dto.GuardianContact).Matches(@"(?:[0-9]\-?){6,14}").NotEmpty();
                    RuleFor(x => x.Dto.Id).NotEmpty().NotNull();
                    RuleFor(x => x.Dto.PhotoAsBase64).Matches(@"^[a-zA-Z0-9\+\/]*={0,2}$");
                    RuleFor(x => x.Dto.Sex).Matches(@"[fm]").NotEmpty();
                    RuleFor(x => x.Dto.Url).Length(1, 150);
                    RuleFor(x => x.Dto.YearOfBirth).NotEmpty().InclusiveBetween(1900, 2020);
                }
            }
        }
    }
}