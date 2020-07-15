using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMM.Features.Department.Queries
{
    public class GetQuery : IRequest<DepartmentResponse>
    {
        public Guid Id { get; set; }
        public GetQuery(Guid id)
        {
            Id = id;
        }
        public class Handler : IRequestHandler<GetQuery, DepartmentResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<DepartmentResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var Department = await _dbContext.Departments
                    .Include(x => x.Volunteers)
                    .FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<DepartmentResponse>(Department);
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
