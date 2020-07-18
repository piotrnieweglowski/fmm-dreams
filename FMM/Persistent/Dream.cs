using System;
using System.Collections.Generic;

namespace FMM.Persistent
{
    public class Dream
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<DreamVolunteer> Volunteers { get; set; }
        public Dreamer Dreamer { get; set; }
        public Guid? DreamerId { get; set; }
        public IList<DreamCategory> Categories { get; set; }
        public bool CanProceed { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}