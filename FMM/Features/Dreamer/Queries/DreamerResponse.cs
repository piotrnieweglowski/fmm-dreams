using System;
using AutoMapper;

namespace FMM.Features.Dreamer.Queries
{
    public class DreamerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public Dream Dream { get; set; }
        public int YearOfBirth { get; set; }
        public string Url { get; set; }
        public string GuardianContact { get; set; }
        public string PhotoAsBase64 { get; set; }

        public class DreamerResponseProfile : Profile
        {
            public DreamerResponseProfile()
            {
                CreateMap<FMM.Persistent.Dream, Dream>();
                CreateMap<FMM.Persistent.Dreamer, DreamerResponse>();
            }
        }
    }

    public class Dream
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}