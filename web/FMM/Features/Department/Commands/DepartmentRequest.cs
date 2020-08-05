using AutoMapper;
using FMM.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Features.Department.Commands
{
    public class DepartmentRequest
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
    public class Volunteer
    {
        public Guid Id { get; set; }
    }
    public class DepartmentRequestProfile : Profile
    {
        public DepartmentRequestProfile()
        {
            CreateMap<Volunteer, FMM.Persistent.Volunteer>();
            CreateMap<DepartmentRequest, FMM.Persistent.Department>();
        }
    }
}
