using System;
using AutoMapper;

namespace FMM.Features.Category.Queries
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class CategoryResponseProfile : Profile
    {
        public CategoryResponseProfile()
        {
            CreateMap<FMM.Persistent.Category, CategoryResponse>();
        }
    }
}
