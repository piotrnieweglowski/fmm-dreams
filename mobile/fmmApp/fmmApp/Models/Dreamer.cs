using System;

namespace fmmApp.Models
{
    [ResourcePath("dreamer")]
    public class Dreamer : ResourceItem<Dreamer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public Dream Dream { get; set; }
        public int YearOfBirth { get; set; }
        public string Url { get; set; }
        public string GuardianFullName { get; set; }
        public string GuardianEmail { get; set; }
        public string GuardianAddress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoAsBase64 { get; set; }
    
    }
}