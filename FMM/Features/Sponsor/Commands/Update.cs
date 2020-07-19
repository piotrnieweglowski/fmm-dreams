using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace FMM.Features.Sponsor.Commands
{
    public class UpdateCommand : IRequest
    {
        public Guid Id { get; }
        public SponsorRequest Dto { get; }

        public UpdateCommand(Guid id, SponsorRequest dto)
        {
            Id = id;
            Dto = dto;
        }

        public class Handler : IRequestHandler<UpdateCommand>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCommand command, CancellationToken cancellationToken)
            {
                var toUpdate = await _dbContext.Sponsors.FirstAsync(x => x.Id == command.Id);
                _mapper.Map<SponsorRequest, Persistent.Sponsor>(command.Dto, toUpdate);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }

        public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
        {
            public UpdateCommandValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Id).Equal(x => x.Id);
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
