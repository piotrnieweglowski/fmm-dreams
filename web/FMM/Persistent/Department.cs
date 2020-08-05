using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Persistent
{
    public class Department
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
}
