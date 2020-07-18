using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
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
            DataContext _dbContext;
            IMapper _mapper;
            
            public Handler (DataContext dbcontext, IMapper mapper)
            {
                _dbContext = dbcontext;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateCommand command, CancellationToken cancellationToken)
            {
                var volunteer = _mapper.Map<Persistent.Volunteer>(command.Dto);
                var dreamId = command.Dto.Dream?.Id;
                if (dreamId.HasValue)
                {
                    volunteer.Dreams.Add(new DreamVolunteer { DreamId = dreamId.Value, VolunteerId = volunteer.Id });
                }
                var departmentId = command.Dto.Department?.Id;
                if (departmentId.HasValue)
                {
                    volunteer.Department = _dbContext.Departments.First(x => x.Id == departmentId);
                }
                var userTypeId = command.Dto.UserType?.Id;
                if (userTypeId.HasValue)
                {
                    volunteer.UserType = _dbContext.UserTypes.First(x => x.Id == userTypeId);
                }
                await _dbContext.Volunteers.AddAsync(volunteer);
                await _dbContext.SaveChangesAsync(cancellationToken);
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
                RuleFor(x => x.Dto.FirstName).NotEmpty().Length(1,100);
                RuleFor(x => x.Dto.LastName).NotEmpty().Length(1,100);
                RuleFor(x => x.Dto.Phone).Length(1, 16);
                RuleFor(x => x.Dto.UserType).NotEmpty().NotNull();
            }
        }
    }
}
