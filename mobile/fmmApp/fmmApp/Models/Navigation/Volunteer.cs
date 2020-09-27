using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace fmmApp.Models.Navigation
{
    /// <summary>
    /// Model for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Volunteer
    {
        #region Properties
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

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
