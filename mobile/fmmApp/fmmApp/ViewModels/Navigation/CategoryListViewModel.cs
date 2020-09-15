using fmmApp.Models;
using fmmApp.Models.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace fmmApp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for the Songs play list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CategoryListViewModel
    {

        #region Fields
        
        private Command<object> itemSelectedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CategoryListViewModel"/> class.
        /// </summary>
        public CategoryListViewModel()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Songs play list page.
        /// </summary>
        [DataMember(Name = "categoryPageList")]
        public ObservableCollection<Category> CategoryPageList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the Songs play list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}
