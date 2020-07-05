using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using FMM.Persistent;

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
    }
}
