using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.UserType.Queries
{
    public class UserTypeResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
    public class UserTypeResponseProfile : Profile
    {
        public UserTypeResponseProfile()
        {
            CreateMap<FMM.Persistent.UserType, UserTypeResponse>();
        }
    }
}
