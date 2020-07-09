using System;
using System.Buffers.Text;
using AutoMapper;
using FMM.Persistent;

namespace FMM.Features.Dreamer.Commands
{
    public class DreamerRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public Dream Dream { get; set; }
        public int YearOfBirth { get; set; }
        public string Url { get; set; }
        public string GuardianContact { get; set; }
        public string PhotoAsBase64 { get; set; }
    }

    public class DreamerRequestProfile : Profile
    {
        public DreamerRequestProfile()
        {
            CreateMap<Dream, FMM.Persistent.Dream>();
            CreateMap<DreamerRequest, FMM.Persistent.Dreamer>();
        }
    }

    public class Dream
    {
        public Guid Id { get; set; }
    }
}