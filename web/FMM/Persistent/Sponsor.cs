using System;
using System.Collections.Generic;

namespace FMM.Persistent
{
    public class Sponsor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInfo { get; set; }
        public IList<Dream> Dreams { get; set; }
    }
}
