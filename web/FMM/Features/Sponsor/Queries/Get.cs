using AutoMapper;
using FMM.Common;
using FMM.Persistent;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Sponsor.Queries
{
    public class GetQuery : IRequest<SponsorResponse>
    {
        public Guid Id;
        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, SponsorResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<SponsorResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var sponsor = await _dbContext.Sponsors.FirstOrDefaultAsync(x => x.Id == query.Id);
                if (sponsor == null)
                {
                    throw new NotFoundException("Sponsor", "Not Found");
                }
                return _mapper.Map<SponsorResponse>(sponsor);
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
