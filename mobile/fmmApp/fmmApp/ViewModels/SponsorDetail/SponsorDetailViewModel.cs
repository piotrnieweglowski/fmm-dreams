using Xamarin.Forms;
using fmmApp.Models.SponsorDetail;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using fmmApp.Views.Navigation;
using fmmApp.Views.Forms;
using fmmApp.Models.Forms;

namespace fmmApp.ViewModels.SponsorDetail
{
    /// <summary>
    /// ViewModel for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SponsorDetailViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<Sponsor> SponsorDetails { get; set; }
        public ObservableCollection<Dreamer> DreamerList { get; set; }
        #endregion

        #region Constructor
        public SponsorDetailViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.EditCommand = new Command(this.EditButtonClicked);
            this.DeleteCommand = new Command(this.DeleteButtonClicked);

            this.SponsorDetails = new ObservableCollection<Sponsor>()
            {
                new Sponsor
                {
                    Name = "John Doe",
                    EmailAddress = "Home@mail.com",
                    ContactNumber = "(828) 228-2882",
                    AdditionalInfo="add info"
                },
            };
            this.DreamerList = new ObservableCollection<Dreamer>()
             {
                new Dreamer
                {
                    FirstName  = "Jan",
                    LastName = "Kowalski",
                    Dream="My dream"
                },
                new Dreamer
                {
                    FirstName  = "Anna",
                    LastName = "Nowak",
                    Dream="My dream"
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
            App.Current.MainPage = new SponsorsListPage();
        }

        /// <summary>
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            App.Current.MainPage = new EditSponsorPage();
        }

        /// <summary>
        /// Invoked when the delete button clicked
        /// </summary>
        /// <param name="obj">The object</param>
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
        /// Gets or sets the command is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the delete button is clicked.
        /// </summary>
        public Command DeleteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand { get; set; }

        #endregion
    }
}
