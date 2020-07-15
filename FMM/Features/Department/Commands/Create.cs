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

namespace FMM.Features.Department.Commands
{
    public class CreateCommand : IRequest
    {
        public DepartmentRequest Dto { get; }

        public CreateCommand(DepartmentRequest dto)
        {
            Dto = dto;
        }
        public class Handler : IRequestHandler<CreateCommand>
        {
            DataContext _dbcontext;
            IMapper _mapper;

            public Handler(DataContext dbcontext, IMapper mapper)
            {
                _dbcontext = dbcontext;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateCommand command, CancellationToken cancellationToken)
            {
                var department = _mapper.Map<Persistent.Department>(command.Dto);
                await _dbcontext.Departments.AddAsync(department);
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.City).NotEmpty();
            }
        }
    }
}
