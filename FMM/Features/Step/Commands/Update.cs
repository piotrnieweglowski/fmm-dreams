using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace FMM.Features.Step.Commands
{
    public class UpdateCommand : IRequest
    {
        public Guid Id { get; }
        public StepRequest Dto { get; }

        public UpdateCommand(Guid id, StepRequest dto)
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
                var toUpdate = await _dbContext.Steps.FirstAsync(x => x.Id == command.Id);
                _mapper.Map<StepRequest, Persistent.Step>(command.Dto, toUpdate);
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
                RuleFor(x => x.Dto.Description).NotNull().NotEmpty().MaximumLength(500);
                RuleFor(x => x.Dto.Tasks).NotNull().NotEmpty();
                RuleForEach(x => x.Dto.Tasks).NotNull().NotEmpty();
                RuleForEach(x => x.Dto.Tasks).ChildRules(tasks =>
                {
                    tasks.RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(500);
                });
            }
        }
    }
}
