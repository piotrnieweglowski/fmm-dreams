using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;

namespace FMM.Features.Category.Commands
{
    public class CreateCommand : IRequest
    {
        public CategoryRequest Dto { get; }

        public CreateCommand(CategoryRequest dto)
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
                var category = _mapper.Map<Persistent.Category>(command.Dto);
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
