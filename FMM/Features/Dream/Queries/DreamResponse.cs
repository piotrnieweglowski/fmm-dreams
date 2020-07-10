using System;
using AutoMapper;

namespace FMM.Features.Dream.Queries
{
    public class DreamResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    public class DreamResponseProfile : Profile
    {
        public DreamResponseProfile()
        {
            CreateMap<FMM.Persistent.Dream, DreamResponse>();
        }
    }
    }
}