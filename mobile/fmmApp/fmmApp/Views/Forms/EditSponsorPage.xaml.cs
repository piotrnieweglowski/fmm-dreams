using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using fmmApp.ViewModels;
using fmmApp.Models;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSponsorPage : ContentPage
    {

        EditSponsorViewModel viewModel;

        public EditSponsorPage()
        {
            InitializeComponent();
        }

        public EditSponsorPage(Sponsor sponsor)
        {
            InitializeComponent();
            viewModel = new EditSponsorViewModel(sponsor);
            BindingContext = viewModel;
        }
    }
}
