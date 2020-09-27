using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using fmmApp.DataService;
using fmmApp.Views.Forms;
using fmmApp.Views.SponsorDetail;
using fmmApp.Services;
using fmmApp.Models;

namespace fmmApp.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DreamerListCardPage : ContentPage
    {
        public DreamerListCardPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = await DreamerListDataService.Instance.PopulateData();
        }
    }
}