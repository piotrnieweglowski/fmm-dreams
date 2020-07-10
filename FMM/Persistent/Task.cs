using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Persistent
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
