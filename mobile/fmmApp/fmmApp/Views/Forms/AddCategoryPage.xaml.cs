﻿
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using fmmApp.Views.Navigation;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// This page used for adding Profile image with Name and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CategoryListPage();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}