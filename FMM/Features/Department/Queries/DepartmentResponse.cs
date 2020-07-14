using AutoMapper;
using FMM.Features.Department.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.Department.Queries
{
    public class DepartmentResponse
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
    public class Volunteer
    {
        public Guid Id { get; set; }
    }
    public class DepartmentResponseProfile : Profile
    {
        public DepartmentResponseProfile()
        {
            CreateMap<FMM.Persistent.Volunteer, Volunteer>();
            CreateMap<FMM.Persistent.Department, DepartmentResponse>();
        }
    }
}
