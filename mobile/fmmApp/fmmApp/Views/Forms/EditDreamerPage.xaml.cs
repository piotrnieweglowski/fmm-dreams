using fmmApp.ViewModels.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using fmmApp.Models.Forms;

namespace fmmApp.Views.Forms
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDreamerPage : ContentPage
    {
        EditDreamerViewModel viewModel;
        public EditDreamerPage(EditDreamerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public EditDreamerPage()
        {
            InitializeComponent();
            //there should be data sourced from dreamer selected from the list
            var dreamer = new Dreamer
            {
                FirstName = "first",
                LastName = "last"
            };
            viewModel = new EditDreamerViewModel(dreamer);
            BindingContext = viewModel;
        }
    }
}