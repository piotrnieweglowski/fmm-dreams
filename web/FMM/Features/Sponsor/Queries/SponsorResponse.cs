using AutoMapper;
using System;

namespace FMM.Features.Sponsor.Queries
{
    public class SponsorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class SponsorProfile : Profile
    {
        public SponsorProfile()
        {
            CreateMap<FMM.Persistent.Sponsor, SponsorResponse>();
        }
    }
}
