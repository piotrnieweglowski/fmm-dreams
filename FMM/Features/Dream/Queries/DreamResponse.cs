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
        public Dreamer Dreamer { get; set; }
        public Sponsor Sponsor { get; set; }
        public IList<Category> Categories { get; set; }
        public bool CanProceed { get; set; }
    }

    public class Dreamer
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }

    public class Sponsor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class DreamResponseProfile : Profile
    {
        public DreamResponseProfile()
        {
            CreateMap<FMM.Persistent.Dreamer, Dreamer>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(x => DateTime.Now.Year - x.YearOfBirth));
            CreateMap<FMM.Persistent.DreamCategory, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Category.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Category.Description));
            CreateMap<FMM.Persistent.Sponsor, Sponsor>();
            CreateMap<FMM.Persistent.Dream, DreamResponse>();
        }
    }
}