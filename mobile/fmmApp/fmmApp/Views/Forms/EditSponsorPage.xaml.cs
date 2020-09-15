using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using fmmApp.Views.SponsorDetail;
using fmmApp.ViewModels;
using fmmApp.Models.SponsorDetail;

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

        public EditSponsorPage(EditSponsorViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public EditSponsorPage()
        {
            InitializeComponent();
            var sponsor = new Sponsor
            {
                Name = "sponsor name",
                EmailAddress = "mail@mail.com",
                PhoneNumber="123456789",
                AdditionalInfo="Additional Info"                
            };
            viewModel = new EditSponsorViewModel(sponsor);
            BindingContext = viewModel;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SponsorDetailPage();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var Sponsor = new Sponsor
            {
                Name = this.NameEntry.Text,
                PhoneNumber = this.PhoneNoEntry.Text,
                EmailAddress = this.EmailAddressEntry.Text,
                AdditionalInfo = this.AdditionalInfoEntry.Text
            };
        }
    }
}