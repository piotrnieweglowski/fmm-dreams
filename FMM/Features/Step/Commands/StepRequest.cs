using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FMM.Features.Step.Commands
{
    public class StepRequest
    {
        public class Step
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public IList<Task> TaskList { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class StepRequestProfile : Profile
        {
            public StepRequestProfile()
            {
                CreateMap<StepRequest, FMM.Persistent.Step>();
            }
        }
    }
}
