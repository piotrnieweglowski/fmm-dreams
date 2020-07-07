using System;

namespace FMM.Persistent
{
    public class Dreamer
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string sex { get; set; }

        public string dream { get; set; }

        public int yearOfBirth { get; set; }

        public string url { get; set; }

        public string guardianContact { get; set; }

        public string photoAsBase64 { get; set; }
    }
}