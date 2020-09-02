using System;

namespace fmmApp.Models
{
    [ResourcePath("dream")]
    public class Dream : ResourceItem<Dream>
    {
        public string Title { get; set; }
    }
}