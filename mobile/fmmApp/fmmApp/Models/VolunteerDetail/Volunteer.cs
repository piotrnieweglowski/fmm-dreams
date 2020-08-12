using Xamarin.Forms.Internals;

namespace fmmApp.Models.Detail
{
    /// <summary>
    /// Model for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Volunteer
    {
        #region Properties
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public string Email { get; set; }

        #endregion
    }
}
