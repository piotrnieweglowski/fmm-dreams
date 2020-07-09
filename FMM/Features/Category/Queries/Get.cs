using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Category.Queries
{
    public class GetQuery : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }

        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, CategoryResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<CategoryResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var category = await _dbContext.Categories.FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<CategoryResponse>(category);
            }
        }
    }
}
