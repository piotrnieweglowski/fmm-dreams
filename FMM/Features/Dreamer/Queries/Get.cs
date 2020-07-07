using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dreamer.Queries
{
    public class GetQuery : IRequest<DreamerResponse>
    {
        public Guid Id { get; set; }

        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, DreamerResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<DreamerResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var dreamer = await _dbContext.Dreamers.FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<DreamerResponse>(dreamer);
            }
        }
    }
}