using Xamarin.Forms;
using fmmApp.Models;
using fmmApp.Models.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using fmmApp.Views.Navigation;
using fmmApp.Views.Detail;

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

        public ObservableCollection<Dreamer> DreamerList { get; set; }

        #endregion

        #region Constructor
        public VolunteerDetailViewModel()
        {
            BackCommand = new Command(BackButtonClicked);
            DeleteCommand = new Command(DeleteButtonClicked);
            NextCommand = new Command(NextButton_Clicked);

            var dream = new Dream()
            {
                Description = "my dream"
            };

            this.VolunteerDetails = new ObservableCollection<Volunteer>()
            {
                new Volunteer
                {
                    FirstName = "John Doe",
                    Email = "mail@mail.com",
                    Department = "114 Ridge St NW, Hudson, NC 28638",
                    Phone = "(828) 228-2882"
                }
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

        public VolunteerDetailViewModel(Volunteer volunteer)
        {
            BackCommand = new Command(BackButtonClicked);
            DeleteCommand = new Command(DeleteButtonClicked);
            NextCommand = new Command(NextButton_Clicked);

            var dream = new Dream()
            {
                Description = "my dream"
            };

            this.VolunteerDetails = new ObservableCollection<Volunteer>()
            {
                volunteer
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

        private void NextButton_Clicked()
        {
            App.Current.MainPage = new VolunteerDetailPage();
        }
        #endregion

        #region Command

        public Command BackCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Command NextCommand { get; set; }

        #endregion
    }
}
