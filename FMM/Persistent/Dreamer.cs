using System;

namespace FMM.Persistent
{
    public class Dreamer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }

        public Dream Dream { get; set; }

        public int YearOfBirth { get; set; }

        public string Url { get; set; }

        public string GuardianContact { get; set; }

        public string PhotoAsBase64 { get; set; }
    }
}