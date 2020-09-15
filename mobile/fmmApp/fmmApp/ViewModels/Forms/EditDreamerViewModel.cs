using fmmApp.Models;
using System;
using Xamarin.Forms;
using fmmApp.Views.Detail;
using fmmApp.Models;

namespace fmmApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    public class EditDreamerViewModel : LoginViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="EditDreamerViewModel" /> class.
        /// </summary>
        public EditDreamerViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.SubmitCommand = new Command(this.SubmitButtonClicked);
            this.CancelCommand = new Command(this.CancelButtonClicked);
        }

        public EditDreamerViewModel(Dreamer dream = null)
        {
            FirstName = dream?.FirstName;
            LastName = dream.LastName;
        }
        #endregion

        #region Property

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string UrlAddress { get; set; }
        public string Dream { get; set; }
        #endregion

        #region Comments
        public Command SubmitCommand { get; set; }

        public Command CancelCommand { get; set; }

        public Command BackCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the submit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SubmitButtonClicked(object obj)
        {
            var dreamer = new Dreamer()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Sex=this.Gender,
                YearOfBirth=this.Date.Year,
                PhoneNumber=this.PhoneNumber,
                Url=this.UrlAddress,
                //dreams guuid
                GuardianAddress=this.Address,
                GuardianEmail=this.Email,
                City=this.City
            };
        }

        private void CancelButtonClicked(object obj)
        {
            //we should pass Dreamer Object to Dreamer Detail Page
            App.Current.MainPage = new DreamerDetailPage();
        }

        private void BackButtonClicked(object obj)
        {

            //App.Current.MainPage = new DreamerListPage();
        }

        #endregion

    }
}
