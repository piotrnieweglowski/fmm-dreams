using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;

namespace FMM.Features.Dream.Commands
{
    public class DreamRequest
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
    public class DreamRequestProfile : Profile
    {
        public DreamRequestProfile()
        {
            CreateMap<Volunteer, FMM.Persistent.Volunteer>();
            CreateMap<DreamRequest, FMM.Persistent.Dream>();
        }
    }
}