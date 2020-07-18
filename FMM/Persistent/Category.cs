using System;
using System.Collections.Generic;

namespace FMM.Persistent
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public IList<DreamCategory> Dreams { get; set; }
    }
}
