using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FMM.Common;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream.Commands
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
                var toRemove = await _dbContext.Dreams.FirstOrDefaultAsync(x => x.Id == command.Id);
                if (toRemove == null)
                {
                    throw new NotFoundException("Dream", "Not found");
                }
                _dbContext.Dreams.Remove(toRemove);
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