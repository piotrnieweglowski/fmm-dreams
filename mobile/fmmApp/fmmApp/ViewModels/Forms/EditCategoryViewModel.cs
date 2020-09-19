using fmmApp.Models;
using fmmApp.Views.Navigation;
using System;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class EditCategoryViewModel : BaseViewModel
    {

        public Category Category { get; set; }

        public EditCategoryViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
        }

        public EditCategoryViewModel(Category category)
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            Category = category;
        }

        public Command BackCommand { get; set; }

        private void BackButtonClicked(object obj)
        {
            App.Current.MainPage = new CategoryListPage();
        }

    }

}

