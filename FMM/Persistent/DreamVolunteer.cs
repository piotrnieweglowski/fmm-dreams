using System;

namespace FMM.Persistent
{
    public class DreamVolunteer
    {
        public Guid Id { get; set; }
        public Guid DreamId { get; set; }
        public Dream Dream { get; set; }
        public Guid VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
