using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace fmmApp.Models.Navigation
{
    /// <summary>
    /// Model for the Songs play list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Category
    {
        #region Field

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an song.
        /// </summary>
        [DataMember(Name = "categoryname")]
        public string CategoryName { get; set; }

        #endregion
    }
}
