using System.Collections.Generic;

namespace FMM.Features.Dream.Queries
{
    public class DreamFilter
    {
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Sex { get; set; }
        public bool? HasSponsor { get; set; }
        public bool? CanProceed { get; set; }
    }
}