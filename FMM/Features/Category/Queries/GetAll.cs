using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Category.Queries
{
    public class GetAllQuery : IRequest<List<CategoryResponse>>
    {
        public GetAllQuery()
        {
        }

        public class Handler : IRequestHandler<GetAllQuery, List<CategoryResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<CategoryResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Categories
                    .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
