using fmmApp.Models;
using fmmApp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class AddStepViewModel : BaseViewModel, INotifyPropertyChanged
    {


        public AddStepViewModel()
        {
            BackCommand = new Command(GoToDreamPage);
            CancelCommand = new Command(GoToDreamPage);
            AddStepCommand = new Command(async () => await AddStep());
        }

        public Step Step { get; set; }
        public Command BackCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command AddStepCommand { get; set; }

        private void GoToDreamPage()
        {
            App.Current.MainPage = new AddDreamPage();
        }

        private async Task AddStep()
        {

            GoToDreamPage();
        }

    }
}

