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

namespace FMM.Features.UserType.Commands
{
    public class CreateCommand : IRequest
    {
        public UserTypeRequest Dto { get; }

        public CreateCommand(UserTypeRequest dto)
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
                var UserType = _mapper.Map<Persistent.UserType>(command.Dto);
                await _dbcontext.UserTypes.AddAsync(UserType);
                await _dbcontext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(x => x.Dto.Id).NotNull().NotEmpty();
                RuleFor(x => x.Dto.Description).NotEmpty().Length(1, 250);
            }
        }
    }
}
