﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FMM.Persistent;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FMM.Common;

namespace FMM.Features.Step.Queries
{
    public class GetQuery : IRequest<StepResponse>
    {
        public Guid Id { get; set; }

        public GetQuery(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetQuery, StepResponse>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<StepResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                var step = await _dbContext.Steps.Include(x => x.Tasks)
                                                    .FirstOrDefaultAsync(x => x.Id == query.Id);
                if (step == null)
                {
                    throw new NotFoundException("Step", "Not found");
                }

                return _mapper.Map<StepResponse>(step);
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
