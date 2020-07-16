using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Sponsor.Queries
{
    public class GetAllQuery : IRequest<List<SponsorResponse>>
    {
        public GetAllQuery()
        {

        }

        public class Handler : IRequestHandler<GetAllQuery, List<SponsorResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<SponsorResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Sponsors
                    .ProjectTo<SponsorResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }

    }
}
