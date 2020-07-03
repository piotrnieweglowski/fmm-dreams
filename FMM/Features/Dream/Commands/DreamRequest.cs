using System;
using AutoMapper;

namespace FMM.Features.Dream.Commands
{
    public class DreamRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class DreamRequestProfile : Profile
    {
        public DreamRequestProfile()
        {
            CreateMap<DreamRequest, FMM.Persistent.Dream>();
        }
    }
}