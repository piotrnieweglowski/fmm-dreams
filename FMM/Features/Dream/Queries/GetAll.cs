using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using FMM.Common;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream.Queries
{
    public class GetAllQuery : IRequest<PagableResponse<DreamResponse>>
    {
        DreamFilter Filter { get; }
        PagingOptions PagingOptions { get; }

        public GetAllQuery(DreamFilter filter, PagingOptions pagingOptions)
        {
            Filter = filter;
            PagingOptions = pagingOptions;
        }

        public class Handler : IRequestHandler<GetAllQuery, PagableResponse<DreamResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PagableResponse<DreamResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                var dreams = _dbContext.Dreams.AsQueryable();
                dreams = FilterMinAge(dreams, query.Filter);
                dreams = FilterMaxAge(dreams, query.Filter);
                dreams = FilterCategories(dreams, query.Filter);
                dreams = FilterSex(dreams, query.Filter);
                dreams = FilterSponsor(dreams, query.Filter);
                dreams = FilterProceed(dreams, query.Filter);

                return await ToResponse(query, dreams, cancellationToken);
            }

            private IQueryable<Persistent.Dream> FilterMinAge(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (filter.MinAge.HasValue)
                {
                    int maxYearOfBirth = DateTime.Now.Year - filter.MinAge.Value;
                    dreams = dreams.Where(x => x.Dreamer != null && x.Dreamer.YearOfBirth <= maxYearOfBirth);
                }

                return dreams;
            }

            private IQueryable<Persistent.Dream> FilterMaxAge(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (filter.MaxAge.HasValue)
                {
                   int minYearOfBirth = DateTime.Now.Year - filter.MaxAge.Value;
                   dreams = dreams.Where(x => x.Dreamer != null && x.Dreamer.YearOfBirth >= minYearOfBirth);
                }

                return dreams;
            }

            private IQueryable<Persistent.Dream> FilterCategories(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (filter.Categories != null && filter.Categories.Any())
                {
                    var categoriesId = _dbContext.Categories.Where(c => filter.Categories.Any(fc => fc == c.Description)).Select(x => x.Id);
                    dreams = dreams.Where(x => x.Categories.Any(x => categoriesId.Contains(x.CategoryId)));
                }

                return dreams;
            }

            private IQueryable<Persistent.Dream> FilterSex(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (!string.IsNullOrWhiteSpace(filter.Sex))
                {
                    dreams = dreams.Where(x => x.Dreamer != null && x.Dreamer.Sex == filter.Sex);
                }

                return dreams;
            }

            private IQueryable<Persistent.Dream> FilterSponsor(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (filter.HasSponsor.HasValue && filter.HasSponsor.Value)
                {
                    dreams = dreams.Where(x => x.Sponsor != null);
                }

                return dreams;
            }

            private IQueryable<Persistent.Dream> FilterProceed(IQueryable<Persistent.Dream> dreams, DreamFilter filter)
            {
                if (filter.CanProceed.HasValue && filter.CanProceed.Value)
                {
                    dreams = dreams.Where(x => x.CanProceed == true);
                }

                return dreams;
            }

            private async Task<PagableResponse<DreamResponse>> ToResponse(GetAllQuery query, IQueryable<Persistent.Dream> dreams, CancellationToken cancellationToken)
            {
                var count = await dreams.CountAsync(cancellationToken);
                var skip = (query.PagingOptions.Page - 1) * query.PagingOptions.PageSize;
                var response = await dreams.Skip(skip)
                                           .Take(query.PagingOptions.PageSize)
                                           .ProjectTo<DreamResponse>(_mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);

                return new PagableResponse<DreamResponse>
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
                RuleFor(x => x.Filter.MinAge).GreaterThanOrEqualTo(3).LessThanOrEqualTo(18);
                RuleFor(x => x.Filter.MaxAge).GreaterThanOrEqualTo(3).LessThanOrEqualTo(18);
                RuleFor(x => x.Filter.Sex).Matches("^[FM]$");
            }
        }
    }
}