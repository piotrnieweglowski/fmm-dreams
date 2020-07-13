using System;
using System.Collections;
using System.Collections.Generic;

namespace FMM.Persistent
{
    public class Dream
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
}