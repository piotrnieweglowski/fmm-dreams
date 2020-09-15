using fmmApp.Models;
using fmmApp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class AddStepViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public int ProgressValue { get; set; }
        public string TaskDescription { get; set; }

        public AddStepViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
        }

        public Command BackCommand { get; set; }

        private void BackButtonClicked(object obj)
        {
            App.Current.MainPage = new AddDreamPage();
        }
    }
}
