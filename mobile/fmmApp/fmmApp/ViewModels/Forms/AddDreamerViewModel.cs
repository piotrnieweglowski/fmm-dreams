using System;
using Xamarin.Forms;

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
            this.SubmitCommand = new Command(this.SubmitButtonClicked);
            this.CancelCommand = new Command(this.CancelButtonClicked);
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the first name from user in the Add Contact page.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the last name from user in the Add Contact page.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker that gets the date from user in the Add Contact page.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a combo box that gets the gender from user in the Add Contact page.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the phone number from user in the Add Contact page.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Address from user in the Add Contact page.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the city from user in the Add Contact page.
        /// </summary>
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
            // Do something
        }

        private void CancelButtonClicked(object obj)
        {
            //App.Current.MainPage = new DreamerListPage();
        }

        private void BackButtonClicked(object obj)
        {
            
            //App.Current.MainPage = new DreamerListPage();
        }
        #endregion

    }
}
