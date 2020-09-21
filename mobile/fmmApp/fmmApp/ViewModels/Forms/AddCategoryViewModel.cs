using fmmApp.Views.Navigation;
using System;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class AddCategoryViewModel : BaseViewModel
    {

        public AddCategoryViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
        }

        public Command BackCommand { get; set; }

        private void BackButtonClicked(object obj)
        {
            App.Current.MainPage = new CategoryListPage();
        }

    }

}

