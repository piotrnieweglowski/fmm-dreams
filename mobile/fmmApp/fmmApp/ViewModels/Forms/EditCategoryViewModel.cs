using fmmApp.DataService;
using fmmApp.Models;
using fmmApp.Views.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class EditCategoryViewModel : BaseViewModel
    {
        public Command BackCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command EditCategoryCommand { get; set; }

        public Category Category { get; set; }

        public EditCategoryViewModel()
        {
            Category = new Category();
            BackCommand = new Command(GoToCategoryListPage);
            CancelCommand = new Command(GoToCategoryListPage);
            EditCategoryCommand = new Command(async () => await UpdateCategory(Category));
        }

        public EditCategoryViewModel(Category category)
        {
            BackCommand = new Command(GoToCategoryListPage);
            CancelCommand = new Command(GoToCategoryListPage);
            EditCategoryCommand = new Command(async () => await UpdateCategory(category));
        }

        private void GoToCategoryListPage()
        {
            App.Current.MainPage = new CategoryListPage();
        }

        private async Task UpdateCategory(Category category)
        {
            await CategoryListDataService.Instance.UpdateCategory(category);
            GoToCategoryListPage();
        }
    }

}

