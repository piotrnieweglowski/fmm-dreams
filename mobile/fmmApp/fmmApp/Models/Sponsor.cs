using System;

namespace fmmApp.Models
{
    [ResourcePath("sponsor")]
    public class Sponsor : ResourceItem<Sponsor>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInfo { get; set;  }
    }
}