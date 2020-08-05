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

namespace FMM.Features.Volunteer.Queries
{
    public class GetQuery : IRequest<VolunteerResponse>
    {
        public Guid Id { get; set; }
        public GetQuery(Guid id)
        {
            Id = id;
        }
        public class Handler : IRequestHandler<GetQuery, VolunteerResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<VolunteerResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var volunteer = await _dbContext.Volunteers.Include(x => x.Department)
                                                            .Include(x => x.Dreams)
                                                            .Include(x => x.UserType)
                                                            .FirstAsync(x => x.Id == query.Id);
                return _mapper.Map<VolunteerResponse>(volunteer);
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
