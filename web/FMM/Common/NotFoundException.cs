using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Common
{
    public class NotFoundException : Exception
    {
        public string Details { get; }
        public NotFoundException(string message, string details) : base(message)
        {
            Details = details;
        }

    }
}
