using fmmApp.Models;
using System;
using Xamarin.Forms;
using fmmApp.Views.Detail;

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
            Dreamer = new Dreamer();
            BackCommand = new Command(GoToDreamerDetailPage);
            SubmitCommand = new Command(SubmitButtonClicked);
            CancelCommand = new Command(GoToDreamerDetailPage);
        }

        public EditDreamerViewModel(Dreamer dream = null)
        {
            Dreamer = new Dreamer();
            BackCommand = new Command(GoToDreamerDetailPage);
            SubmitCommand = new Command(SubmitButtonClicked);
            CancelCommand = new Command(GoToDreamerDetailPage);
        }
        #endregion

        #region Property

        public Dreamer Dreamer { get; set; }
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

        }

        private void GoToDreamerDetailPage()
        {
            App.Current.MainPage = new DreamerDetailPage();
        }

        #endregion

    }
}
