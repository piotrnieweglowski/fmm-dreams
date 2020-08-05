using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream.Commands
{
    public class UpdateCommand : IRequest
    {
        public Guid Id { get; }
        public DreamRequest Dto { get; }

        public UpdateCommand(Guid id, DreamRequest dto)
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
                var toUpdate = await _dbContext.Dreams.FirstAsync(x => x.Id == command.Id);
                _mapper.Map<DreamRequest, Persistent.Dream>(command.Dto, toUpdate);
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
                RuleFor(x => x.Dto.Description).NotEmpty();
                RuleFor(x => x.Dto.Title).NotEmpty();
            }
        }
    }
}