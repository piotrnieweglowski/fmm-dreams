using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.UserType.Commands
{
    public class UserTypeRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
    public class UserTypeRequestProfile : Profile
    {
        public UserTypeRequestProfile()
        {
            CreateMap<UserTypeRequest, FMM.Persistent.UserType>();
        }
    }
}
