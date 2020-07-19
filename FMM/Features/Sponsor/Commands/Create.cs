using AutoMapper;
using FMM.Persistent;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using System;

namespace FMM.Features.Sponsor.Commands
{
    public class CreateCommand : IRequest
    {
        public SponsorRequest Dto { get; }

        public CreateCommand(SponsorRequest dto)
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
                var sponsor = _mapper.Map<Persistent.Sponsor>(command.Dto);
                await _dbContext.Sponsors.AddAsync(sponsor);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }

        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Name).NotNull().NotEmpty().MaximumLength(100);
                RuleFor(x => x.Dto.PhoneNumber).NotNull()
                    .Matches("^\\d{9}$").When(x => !String.IsNullOrEmpty(x.Dto.PhoneNumber));
                RuleFor(x => x.Dto.EmailAddress).NotNull()
                    .EmailAddress().When(x => !String.IsNullOrEmpty(x.Dto.EmailAddress));
                RuleFor(x => x.Dto.AdditionalInfo).NotNull()
                    .MaximumLength(500).When(x => !String.IsNullOrEmpty(x.Dto.AdditionalInfo));
            }
        }
    }
}
