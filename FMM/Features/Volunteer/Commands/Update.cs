using AutoMapper;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMM.Features.Volunteer.Commands
{
    public class UpdateCommand : IRequest
    {
        public Guid Id { get; }
        public VolunteerRequest Dto { get; }
        
        public UpdateCommand(Guid id, VolunteerRequest dto)
        {
            Id = id;
            Dto = dto;
        }
        public class Handler : IRequestHandler<UpdateCommand>
        {
            DataContext _dbContext;
            IMapper _mapper;
            public Handler(DataContext dbcontext, IMapper mapper)
            {
                _dbContext = dbcontext;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(UpdateCommand command, CancellationToken cancellationToken)
            {
                var toUpdate = await _dbContext.Volunteers.FirstAsync(x => x.Id == command.Id );
                _mapper.Map<VolunteerRequest, Persistent.Volunteer>(command.Dto, toUpdate);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
