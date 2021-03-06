using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using fmmApp.Views.Navigation;
using fmmApp.Views.Forms;
using fmmApp.Models;

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

            var dream = new Dream()
            {
                Description = "dream"
            };

            /*
            this.SponsorDetails = new ObservableCollection<Models.SponsorDetail.Sponsor>()
            {
                sponsor
                /*new Models.SponsorDetail.Sponsor
                {
                    Name = "John Doe",
                    EmailAddress = "Home@mail.com",
                    PhoneNumber = "(828) 228-2882",
                    AdditionalInfo="add info"
                },
                
            };
        */
            this.DreamerList = new ObservableCollection<Dreamer>()
             {
                new Dreamer
                {
                    FirstName  = "Jan",
                    LastName = "Kowalski",
                    Dream=dream
                },
                new Dreamer
                {
                    FirstName  = "Anna",
                    LastName = "Nowak",
                    Dream=dream
                }
            };
        }
        public SponsorDetailViewModel(Sponsor sponsor)
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.EditCommand = new Command(this.EditButtonClicked);
            this.DeleteCommand = new Command(this.DeleteButtonClicked);

            var dream = new Dream()
            {
                Description = "dream"
            };

            this.SponsorDetails = new ObservableCollection<Sponsor>()
            {
                sponsor
                /*new Models.SponsorDetail.Sponsor
                {
                    Name = "John Doe",
                    EmailAddress = "Home@mail.com",
                    PhoneNumber = "(828) 228-2882",
                    AdditionalInfo="add info"
                },
                */
            };
            this.DreamerList = new ObservableCollection<Dreamer>()
             {
                new Dreamer
                {
                    FirstName  = "Jan",
                    LastName = "Kowalski",
                    Dream=dream
                },
                new Dreamer
                {
                    FirstName  = "Anna",
                    LastName = "Nowak",
                    Dream=dream
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
            //App.Current.MainPage = new EditSponsorPage();
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
