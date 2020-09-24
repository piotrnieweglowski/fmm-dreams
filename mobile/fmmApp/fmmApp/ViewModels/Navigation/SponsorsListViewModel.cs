using Xamarin.Forms;
using fmmApp.Models.Navigation;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;
using fmmApp.Views.SponsorDetail;
using fmmApp.Models;
using fmmApp.Views.Forms;

namespace fmmApp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for icon names list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SponsorsListViewModel
    {
        #region Fields

        private Sponsor sponsor;

        private Command<object> itemTappedCommand;

        private Command nextCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SponsorsListViewModel"/> class.
        /// </summary>
        public SponsorsListViewModel()
        {
            AddCommand = new Command(AddSponsorCommand);
        }
        #endregion

        #region Properties

        public Command AddCommand { get; set; }
        public Command DetailsCommand { get; set; }

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
        [DataMember(Name = "sponsorsListPage")]
        public ObservableCollection<Sponsor> SponsorsList { get; set; }

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

        private void AddSponsorCommand()
        {
            App.Current.MainPage = new AddSponsorPage();
        }
        #endregion
    }
}
