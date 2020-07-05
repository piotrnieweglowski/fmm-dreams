using System;
using AutoMapper;
using System.Collections.Generic;

namespace FMM.Features.Step.Queries
{
    public class StepResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public IList<FMM.Persistent.Task> TaskList { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class StepResponseProfile : Profile
    {
        public StepResponseProfile()
        {
            CreateMap<FMM.Persistent.Step, StepResponse>();
        }
    }
}
