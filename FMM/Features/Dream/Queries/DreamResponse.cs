using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace FMM.Features.Dream.Queries
{
    public class DreamResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
    public class Volunteer
    {
        public Guid Id { get; set; }
    }
    public class DreamResponseProfile : Profile
    {
        public DreamResponseProfile()
        {
            CreateMap<FMM.Persistent.Volunteer, Volunteer>();
            CreateMap<FMM.Persistent.Dream, DreamResponse>();
        }
    }
}