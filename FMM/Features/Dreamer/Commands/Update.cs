using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FMM.Persistent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dreamer.Commands
{
    public class UpdateCommand : IRequest
    {
        public Guid Id { get; }
        public DreamerRequest Dto { get; }

        public UpdateCommand(Guid id, DreamerRequest dto)
        {
            Id = id;
            Dto = dto;
        }

        public class Handler : IRequestHandler<UpdateCommand>
        {
            DataContext _dbContext;
            IMapper _mapper;

            public Handler(DataContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCommand command, CancellationToken cancellationToken)
            {
                var toUpdate = await _dbContext.Dreamers.FirstAsync(x => x.Id == command.Id);
                _mapper.Map<DreamerRequest, Persistent.Dreamer>(command.Dto, toUpdate);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
            {
                public UpdateCommandValidator()
                {
                    RuleFor(x => x.Dto.Dream).NotNull().NotEmpty();
                    RuleFor(x => x.Dto.FirstName).Length(1, 100).NotEmpty();
                    RuleFor(x => x.Dto.GuardianContact).Matches(@"(?:[0-9]\-?){6,14}").NotEmpty();
                    RuleFor(x => x.Dto.Id).NotEmpty().NotNull();
                    RuleFor(x => x.Dto.PhotoAsBase64).Matches(@"^[a-zA-Z0-9\+\/]*={0,2}$");
                    RuleFor(x => x.Dto.Sex).Matches(@"[fm]").NotEmpty();
                    RuleFor(x => x.Dto.Url).Length(1, 150);
                    RuleFor(x => x.Dto.YearOfBirth).NotEmpty().InclusiveBetween(1900, 2020);
                }
            }
        }
    }
}