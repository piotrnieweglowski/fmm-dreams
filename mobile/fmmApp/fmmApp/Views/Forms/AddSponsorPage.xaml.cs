using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using fmmApp.Views.Navigation;
using fmmApp.Models;
using fmmApp.DataService;
using System.Threading.Tasks;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSponsorPage : ContentPage
    {
        public AddSponsorPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SponsorsListPage();
        }


        public void AddButton_Clicked(object sender, EventArgs e)
        {
            var sponsor = new Sponsor
            {
                Name = this.NameEntry.Text,
                PhoneNumber = this.PhoneNoEntry.Text,
                EmailAddress = this.EmailAddressEntry.Text,
                AdditionalInfo = this.AdditionalInfoEntry.Text
            };
            //return await SponsorsListDataService.Instance.SaveNewSponsor(sponsor);
        } 

        /* private async Task<bool> AddButton_Clicked(object sender, EventArgs e)
        {
            var sponsor = new Sponsor
            {
                Name = this.NameEntry.Text,
                PhoneNumber = this.PhoneNoEntry.Text,
                EmailAddress = this.EmailAddressEntry.Text,
                AdditionalInfo = this.AdditionalInfoEntry.Text
            };
            return await SponsorsListDataService.Instance.SaveNewSponsor(sponsor);
        }
        */
    }
}