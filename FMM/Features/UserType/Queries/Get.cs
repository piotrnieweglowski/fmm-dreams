using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMM.Features.UserType.Queries
{
    public class GetQuery : IRequest<UserTypeResponse>
    {
        public Guid Id { get; set; }
        public GetQuery(Guid id)
        {
            Id = id;
        }
        public class Handler : IRequestHandler<GetQuery, UserTypeResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<UserTypeResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var UserType = await _dbContext.UserTypes.FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<UserTypeResponse>(UserType);
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
}
