using System;

namespace FMM.Persistent
{
    public class DreamCategory
    {
        public Guid Id { get; set; }
        public Guid DreamId { get; set; }
        public Dream Dream { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
