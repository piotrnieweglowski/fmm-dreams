using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dreamer.Queries
{
    public class GetAllQuery : IRequest<List<DreamerResponse>>
    {
        public GetAllQuery()
        {
        }

        public class Handler : IRequestHandler<GetAllQuery, List<DreamerResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<DreamerResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Dreams
                    .ProjectTo<DreamerResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}