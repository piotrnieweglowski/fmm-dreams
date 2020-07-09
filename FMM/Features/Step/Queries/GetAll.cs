using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Step.Queries
{
    public class GetAllQuery : IRequest<List<StepResponse>>
    {
        public GetAllQuery()
        {
        }


        public class Handler : IRequestHandler<GetAllQuery, List<StepResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<StepResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Steps
                    .ProjectTo<StepResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
