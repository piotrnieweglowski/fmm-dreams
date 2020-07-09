using AutoMapper;
using System;

namespace FMM.Features.Category.Commands
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class CategoryRequestProfile : Profile
    {
        public CategoryRequestProfile()
        {
            CreateMap<CategoryRequest, FMM.Persistent.Category>();
        }
    }
}
