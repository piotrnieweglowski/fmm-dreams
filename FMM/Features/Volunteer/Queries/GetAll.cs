using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FMM.Common;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System;
using FluentValidation;

namespace FMM.Features.Volunteer.Queries
{
    public class GetAllQuery : IRequest<PagableResponse<VolunteerResponse>>
    {
        VolunteerFilter Filter { get; }
        PagingOptions PagingOptions { get; }
        public GetAllQuery(VolunteerFilter filter, PagingOptions pagingOptions)
        {
            Filter = filter;
            PagingOptions = pagingOptions;
        }
        public class Handler : IRequestHandler<GetAllQuery, PagableResponse<VolunteerResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<PagableResponse<VolunteerResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                var volunteers = _dbContext.Volunteers.AsQueryable();
                volunteers = FilterDepartment(volunteers, query.Filter);
                return await ToResponse(query, volunteers, cancellationToken);
            }

            private IQueryable<Persistent.Volunteer> FilterDepartment(IQueryable<Persistent.Volunteer> volunteers, VolunteerFilter filter)
            {
                if (filter.Department != null && filter.Department.Any())
                {
                    var departmentsId = _dbContext.Departments.Where(c => filter.Department.Any(fc => fc == c.City))
                        .Select(x => x.Id);
                    volunteers = volunteers.Where(x => x.Department.Equals(departmentsId));
                }
                return volunteers;
            }

            private async Task<PagableResponse<VolunteerResponse>> ToResponse(GetAllQuery query, IQueryable<Persistent.Volunteer> volunteers, CancellationToken cancellationToken)
            {
                var count = await volunteers.CountAsync(cancellationToken);
                var skip = (query.PagingOptions.Page - 1) * query.PagingOptions.PageSize;
                var response = await volunteers.Skip(skip)
                                           .Take(query.PagingOptions.PageSize)
                                           .ProjectTo<VolunteerResponse>(_mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);

                return new PagableResponse<VolunteerResponse>
                {
                    AllItemsCount = count,
                    Response = response,
                    Page = query.PagingOptions.Page,
                    PageSize = query.PagingOptions.PageSize,
                    PagesCount = (int)Math.Ceiling(count / (decimal)query.PagingOptions.PageSize)
                };
            }
        }

        public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
        {
            public GetAllQueryValidator()
            {
                RuleFor(x => x.PagingOptions.Page).GreaterThan(0);
                RuleFor(x => x.PagingOptions.PageSize).GreaterThan(0);
                //rule for filter?
            }
        }
    }
}
