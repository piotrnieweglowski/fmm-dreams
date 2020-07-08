using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
    }
}
