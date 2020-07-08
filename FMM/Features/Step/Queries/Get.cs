using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Step.Queries
{
    public class GetQuery : IRequest<StepResponse>
    {
        public Guid Id { get; set; }

        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, StepResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<StepResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var dream = await _dbContext.Steps.Include(x => x.Tasks).FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<StepResponse>(dream);
            }
        }
    }
}
