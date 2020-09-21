using fmmApp.DataService;
using fmmApp.Models;
using fmmApp.Views.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fmmApp.ViewModels.Forms
{
    public class AddCategoryViewModel : BaseViewModel
    {

        public AddCategoryViewModel()
        {
            Category = new Category();
            BackCommand = new Command(GoToCategoryListPage);
            CancelCommand = new Command(GoToCategoryListPage);
            AddCategoryCommand = new Command(async () => await AddCategory());
        }

        public Command BackCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command AddCategoryCommand { get; set; }

        public Category Category { get; set; }

        private void GoToCategoryListPage()
        {
            App.Current.MainPage = new CategoryListPage();
        }

        private async Task AddCategory()
        {
            await CategoryListDataService.Instance.SaveNewCategory(Category);
            GoToCategoryListPage();
        }
    }

}

