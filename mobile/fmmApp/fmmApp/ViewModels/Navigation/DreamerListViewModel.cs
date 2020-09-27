using Xamarin.Forms;
using fmmApp.Models.Navigation;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;
using fmmApp.Views.Forms;

namespace fmmApp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for icon names list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DreamerListViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command nextCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="DreamerListViewModel"/> class.
        /// </summary>
        public DreamerListViewModel()
        {

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets the next command that will be executed when an item is selected.
        /// </summary>   
        public Command NextCommand
        {
            get
            {
                return this.nextCommand ?? (this.nextCommand = new Command(this.NextClicked));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in icon names list page.
        /// </summary>
        [DataMember(Name = "dreamersListPage")]
        public ObservableCollection<DreamerModel> DreamerList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the icon names list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something

        }

        /// <summary>
        /// Invoked when the Next button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NextClicked(object obj)
        {
            
        }

        #endregion
    }
}
