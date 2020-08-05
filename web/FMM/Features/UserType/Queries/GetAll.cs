using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class GetAllQuery : IRequest<List<UserTypeResponse>>
    {
        public GetAllQuery()
        {

        }
        public class Handler : IRequestHandler<GetAllQuery, List<UserTypeResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<List<UserTypeResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.UserTypes.ProjectTo<UserTypeResponse>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);
            }
        }
    }
}
