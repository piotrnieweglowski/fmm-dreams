using AutoMapper;
using System;


namespace FMM.Features.Sponsor.Commands
{
    public class SponsorRequest
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
            CreateMap<SponsorRequest, FMM.Persistent.Sponsor>();
        }
    }
}
