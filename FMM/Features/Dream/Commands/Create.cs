using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;

namespace FMM.Features.Dream.Commands
{
    public class CreateCommand : IRequest
    {
        public DreamRequest Dto { get; }

        public CreateCommand(DreamRequest dto)
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
                var dream = _mapper.Map<Persistent.Dream>(command.Dto);
                await _dbContext.Dreams.AddAsync(dream);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}