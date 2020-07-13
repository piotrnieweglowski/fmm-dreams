using AutoMapper;
using FluentValidation;
using FluentValidation.Validators;
using FMM.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
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
        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Department).NotEmpty();
                RuleFor(x => x.Dto.Email).EmailAddress();
                RuleFor(x => x.Dto.FirstName).NotEmpty();
                RuleFor(x => x.Dto.LastName).NotEmpty();
                RuleFor(x => x.Dto.Phone).Length(1, 12);
                RuleFor(x => x.Dto.UserType).NotEmpty().NotNull();
            }
        }
    }
}
