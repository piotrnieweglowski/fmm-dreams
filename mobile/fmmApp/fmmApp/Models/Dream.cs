﻿using fmmApp.Models.Detail;
using System;
using System.Collections.Generic;

namespace fmmApp.Models
{
    [ResourcePath("dream")]
    public class Dream : ResourceItem<Dream>
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid DreamerGuid { get; set; }
        public Volunteer Volunteer;
    }
}