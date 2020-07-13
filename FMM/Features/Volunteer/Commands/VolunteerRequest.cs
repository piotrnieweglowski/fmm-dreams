using AutoMapper;
using FMM.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.Volunteer.Commands
{
    public class VolunteerRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public Dream Dream { get; set; }
    }
    public class Dream
    {
        public Guid Id;
    }
    public class Department
    {
        public Guid Id { get; set; }
    }
    public class UserType
    {
        public Guid Id { get; set; }
    }
    public class VolunteerRequestProfile : Profile
    {
        public VolunteerRequestProfile()
        {
            CreateMap<Dream, FMM.Persistent.Dream>();
            CreateMap<Department, FMM.Persistent.Department>();
            CreateMap<UserType, FMM.Persistent.UserType>();
            CreateMap<VolunteerRequest, FMM.Persistent.Volunteer>();
        }
    }
}
