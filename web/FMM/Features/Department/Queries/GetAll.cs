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

namespace FMM.Features.Department.Queries
{
    public class GetAllQuery : IRequest<List<DepartmentResponse>>
    {
        public GetAllQuery()
        {

        }
        public class Handler : IRequestHandler<GetAllQuery, List<DepartmentResponse>>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<List<DepartmentResponse>> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                return await _dbContext.Departments
                                .ProjectTo<DepartmentResponse>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);
            }
        }
    }
}
