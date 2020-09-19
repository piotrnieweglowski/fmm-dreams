using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using fmmApp.Views.Navigation;
using fmmApp.Models;
using fmmApp.DataService;
using System.Threading.Tasks;
using fmmApp.ViewModels.Forms;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategoryPage : ContentPage
    {
        Category _selectedCategory;
        public EditCategoryPage()
        {
            InitializeComponent();
        }

        public EditCategoryPage(Category category)
        {
            InitializeComponent();
            _selectedCategory = category;
            var viewModel = new EditCategoryViewModel(category);
            this.BindingContext = viewModel;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CategoryListPage();
        }
        
        public async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await CategoryListDataService.Instance.UpdateCategory(_selectedCategory);
            App.Current.MainPage = new CategoryListPage();
        }
      

    }
}