﻿using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace fmmApp.Models.Navigation
{
    /// <summary>
    /// Model for the Navigation List and Tile with Cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NavigationModel
    {
        #region Field

        private string itemImage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an item.
        /// </summary>
        [DataMember(Name = "itemName")]
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the description of an item.
        /// </summary>
        [DataMember(Name = "dream")]
        public string Dream { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        [DataMember(Name = "itemImage")]
        public string ItemImage
        {
            get
            {
                return App.BaseImageUrl + this.itemImage;
            }

            set
            {
                this.itemImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the average rating of an item.
        /// </summary>
        [DataMember(Name = "dreamerAge")]
        public double DreamerAge { get; set; }

        #endregion
    }
}