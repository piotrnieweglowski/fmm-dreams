using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.Volunteer.Queries
{
    public class VolunteerResponse
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
        public Guid Id { get; set; }
    }
    public class Department
    {
        public Guid Id { get; set; }
    }
    public class UserType
    {
        public Guid Id { get; set; }
    }
    public class VolunteerResponseProfile : Profile
    {
        public VolunteerResponseProfile()
        {
            CreateMap<FMM.Persistent.Dream, Dream>();
            CreateMap<FMM.Persistent.Department, Department>();
            CreateMap<FMM.Persistent.UserType, UserType>();
            CreateMap<FMM.Persistent.Volunteer, VolunteerResponse>();
        }
    }
}
