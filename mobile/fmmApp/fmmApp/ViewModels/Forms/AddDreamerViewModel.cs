using fmmApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fmmApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    public class AddDreamerViewModel : LoginViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="AddDreamerViewModel" /> class.
        /// </summary>
        public AddDreamerViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.CancelCommand = new Command(this.CancelButtonClicked);
            this.SubmitCommand = new Command(this.SubmitButtonClicked);
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
        public string EmailAddress { get; set; }
        public string GuardianFullName { get; set; }
        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command that will be executed when the submit button is clicked.
        /// </summary>
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
                YearOfBirth = this.Date.Year,
                Sex = this.Gender,
                GuardianFullName = this.GuardianFullName,
                GuardianEmail = this.EmailAddress,
                GuardianAddress = this.Address,
                City = this.City,
                PhoneNumber = this.PhoneNumber,
                Url=""               
            };

        }

        private void CancelButtonClicked(object obj)
        {
            //confirm you don't want to save changes
            //go to Main Page/Dreamer List?
            //App.Current.MainPage = new DreamerListPage();
        }

        private void BackButtonClicked(object obj)
        {
            //confirm you don't want to save changes
            //go to Main Page/Dreamer List?
            //App.Current.MainPage = new DreamerListPage();
        }
        #endregion

    }
}
