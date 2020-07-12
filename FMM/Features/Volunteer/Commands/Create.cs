using AutoMapper;
using FMM.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMM.Features.Volunteer.Commands
{
    public class CreateCommand : IRequest
    {
        public VolunteerRequest Dto { get; }

        public CreateCommand(VolunteerRequest dto)
        {
            Dto = dto;
        }
        public class Handler : IRequestHandler<CreateCommand>
        {
            DataContext _dbcontext;
            IMapper _mapper;
            
            public Handler (DataContext dbcontext, IMapper mapper)
            {
                _dbcontext = dbcontext;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateCommand command, CancellationToken cancellationToken)
            {
                var volunteer = _mapper.Map<Persistent.Volunteer>(command.Dto);
                await _dbcontext.Volunteers.AddAsync(volunteer);
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
