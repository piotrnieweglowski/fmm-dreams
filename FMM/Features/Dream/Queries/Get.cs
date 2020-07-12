using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream.Queries
{
    public class GetQuery : IRequest<DreamResponse>
    {
        public Guid Id { get; set; }

        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, DreamResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<DreamResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var dream = await _dbContext.Dreams.FirstOrDefaultAsync(x => x.Id == query.Id);
                return _mapper.Map<DreamResponse>(dream);
            }
        }

        public class GetQueryValidator : AbstractValidator<GetQuery>
        {
            public GetQueryValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
            }
        }
    }
}