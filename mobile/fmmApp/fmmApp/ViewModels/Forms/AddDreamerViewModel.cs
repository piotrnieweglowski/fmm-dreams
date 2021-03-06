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
            Dreamer = new Dreamer();
            BackCommand = new Command(BackButtonClicked);
            CancelCommand = new Command(CancelButtonClicked);
            SubmitCommand = new Command(SubmitButtonClicked);
        }

        #endregion

        #region Property
        public Dreamer Dreamer { get; set; }
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
            var dreamer = Dreamer;

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
