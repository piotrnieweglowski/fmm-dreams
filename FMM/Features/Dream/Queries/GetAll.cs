using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream.Queries
{
    public class GetAllQuery : IRequest<List<DreamResponse>>
    {
        public GetAllQuery()
        {
        }

        public class Handler : IRequestHandler<GetAllQuery, List<DreamResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<DreamResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Dreams
                    .ProjectTo<DreamResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}