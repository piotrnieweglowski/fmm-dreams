using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;
using fmmApp.Views.Forms;
using fmmApp.Models.Navigation;

namespace fmmApp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for icon names list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class VolunteerListViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Volunteer volunteer;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="VolunteerListViewModel"/> class.
        /// </summary>
        public VolunteerListViewModel()
        {
            AddCommand = new Command(AddClicked);
            volunteer = new Volunteer()
            {
                FirstName = "Domi",
                LastName = "Test",
                Email = "mail@test.com",
                Department = "Bdg",
                Phone = "123455"
            };
            VolunteerList = new ObservableCollection<Volunteer>();
            VolunteerList.Add(volunteer);
        }
        #endregion

        #region Properties

        // <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
      /*  public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }
      */

        /// <summary>
        /// Gets or sets the next command that will be executed when an item is selected.
        /// </summary>   
        public Command NextCommand { get; set; }

        public Command ItemTappedCommand { get; set; }
        public Command AddCommand { get; set; }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in icon names list page.
        /// </summary>
        [DataMember(Name = "volunteerListPage")]
        public ObservableCollection<Volunteer> VolunteerList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the icon names list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            // Do something
            var volunteer = e.ItemData as Volunteer;
            //App.Current.MainPage = new EditVolteerPage();

        }

        /// <summary>
        /// Invoked when the Next button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NextClicked(object obj)
        {
            //Present Volunteer Details
            var volunteer = obj as Volunteer;
            //App.Current.MainPage = new EditVolteerPage();
        }

        private void AddClicked(object obj)
        {
            App.Current.MainPage = new AddVolunteerPage();
        }
        #endregion
    }
}
