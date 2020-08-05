using System;
using System.Collections.Generic;

namespace FMM.Persistent
{
    public class Step
    {
        public Guid Id { get; set; }
        public string Description { get; set; } 
        public IList<Task> Tasks { get; set; }
        public bool IsCompleted { get; set; }
    }
}
