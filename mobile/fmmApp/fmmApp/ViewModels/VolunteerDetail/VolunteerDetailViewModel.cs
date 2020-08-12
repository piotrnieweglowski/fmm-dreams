using Xamarin.Forms;
using fmmApp.Models.Detail;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using fmmApp.Views.Navigation;
using fmmApp.Models;

namespace fmmApp.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class VolunteerDetailViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<Volunteer> VolunteerDetails { get; set; }

        
        #endregion

        #region Constructor
        public VolunteerDetailViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.DeleteCommand = new Command(this.DeleteButtonClicked);

            this.VolunteerDetails = new ObservableCollection<Volunteer>()
            {
                new Volunteer
                {
                    FullName = "John Doe",
                    Email = "mail@mail.com",
                    Department = "114 Ridge St NW, Hudson, NC 28638",
                    Phone = "(828) 228-2882"
                }
            };

        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            App.Current.MainPage = new VolunteerListPage();
        }

        /// <summary>
        /// Invoked when the delete button clicked
        /// </summary>
        /// <param name="obj">The object</param>

        /// it should not be visible for all volunteers
        private void DeleteButtonClicked(object obj)
        {
            // Do something
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the delete button is clicked.
        /// </summary>
        public Command DeleteCommand { get; set; }

        #endregion
    }
}
