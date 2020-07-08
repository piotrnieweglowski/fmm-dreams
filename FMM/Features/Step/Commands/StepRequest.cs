using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace FMM.Features.Step.Commands
{
    public class StepRequest
    {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public IList<Task> Tasks { get; set; }
            public bool IsCompleted { get; set; }
    }

    public class Task
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class StepRequestProfile : Profile
    {
        public StepRequestProfile()
        {
            CreateMap<Task, FMM.Persistent.Task>();
            CreateMap<StepRequest, FMM.Persistent.Step>();
        }
    }
}
