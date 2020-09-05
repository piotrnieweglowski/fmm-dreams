using fmmApp.Models;
using fmmApp.ViewModels.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStepPage : ContentPage
    {
        public AddStepPage()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AddDreamPage();
        }
    }
}