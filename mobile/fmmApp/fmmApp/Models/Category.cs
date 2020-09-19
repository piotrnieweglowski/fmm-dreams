using System;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace fmmApp.Models
{
    [ResourcePath("category")]
    
    public class Category : ResourceItem<Category>
    {
        public string Description { get; set; }
    }
}
