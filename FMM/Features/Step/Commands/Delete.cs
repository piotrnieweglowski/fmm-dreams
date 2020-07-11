using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FMM.Persistent;
using FluentValidation;

namespace FMM.Features.Step.Commands
{
    public class DeleteCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteCommand(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<DeleteCommand>
        {
            DataContext _dbContext;

            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteCommand command, CancellationToken cancellationToken)
            {
                var toRemove = await _dbContext.Steps.FirstAsync(x => x.Id == command.Id);
                _dbContext.Steps.Remove(toRemove);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
        public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
        {
            public DeleteCommandValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
            }
        }
    }
}
