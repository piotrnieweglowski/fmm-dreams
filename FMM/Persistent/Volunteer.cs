using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMM.Persistent
{
    public class Volunteer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<Dream> Dreams { get; set; }
        public UserType UserType { get; set; }
    }
}
