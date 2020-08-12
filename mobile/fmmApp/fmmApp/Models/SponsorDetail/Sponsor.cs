using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace fmmApp.Models.SponsorDetail
{
    /// <summary>
    /// Model for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Sponsor
    {
        #region Properties
        /// <summary>
        /// Gets or sets user name.
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public string ContactNumber { get; set; }

        #endregion
    }
}
