using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FMM.Persistent;
using FluentValidation;

namespace FMM.Features.Step.Commands
{
    public class CreateCommand : IRequest
    {
        public StepRequest Dto { get; }

        public CreateCommand(StepRequest dto)
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
                var step = _mapper.Map<Persistent.Step>(command.Dto);
                await _dbContext.Steps.AddAsync(step);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }

        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Description).NotEmpty().NotNull().MaximumLength(500);
                RuleFor(x => x.Dto.Tasks).NotEmpty().NotNull();
                RuleForEach(x => x.Dto.Tasks).NotNull().NotEmpty();
                RuleForEach(x => x.Dto.Tasks).ChildRules(tasks =>
                {
                    tasks.RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(500);
                });
                RuleFor(x => x.Dto.IsCompleted).NotNull();
            }
        }
    }
}
