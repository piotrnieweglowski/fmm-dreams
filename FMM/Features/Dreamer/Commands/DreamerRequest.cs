using System;
using System.Buffers.Text;
using AutoMapper;
using FMM.Persistent;

namespace FMM.Features.Dreamer.Commands
{
    public class DreamerRequest
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string sex { get; set; }
        
        public string dream { get; set; }

        public int yearOfBirth { get; set; }

        public string url { get; set; }
        
        public string guardianContact { get; set; }

        public string photoAsBase64 { get; set; }

    }

    public class DreamerRequestProfile : Profile
    {
        public DreamerRequestProfile()
        {
            CreateMap<DreamerRequest, FMM.Persistent.Dreamer>();
        }
    }
}