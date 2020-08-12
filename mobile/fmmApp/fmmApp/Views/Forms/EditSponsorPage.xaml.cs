using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using fmmApp.Views.SponsorDetail;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSponsorPage : ContentPage
    {
        public EditSponsorPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SponsorDetailPage();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SponsorDetailPage();
        }
    }
}