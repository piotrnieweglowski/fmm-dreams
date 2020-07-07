using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
                await _dbContext.Dreamers.AddAsync(dreamer);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}