using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace fmmApp.Models.Navigation
{
    /// <summary>
    /// Model for the contact.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class VolunteerModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "department")]
        public string Department { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the background color for the contacts inside avatar view.
        /// </summary>
        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the names selected.
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion
    }
}
