﻿using fmmApp.Models;
using fmmApp.Models.Detail;
using fmmApp.ViewModels;
using fmmApp.Views.Navigation;
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
    public partial class AddVolunteerPage : ContentPage
    {
        public AddVolunteerPage()
        {
            InitializeComponent();
            this.BindingContext = new AddVolunteerViewModel
            {
                DepartmentList = GetDepartments()
            };
        }

        private List<Department> GetDepartments()
        {
            var depOne = new Department
            {
                City = "Wwa"
            };
            var depTwo = new Department
            {
                City = "Krk"
            };
            var departmentList = new List<Department>();
            departmentList.Add(depOne);
            departmentList.Add(depTwo);
            return departmentList;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new VolunteerListPage();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var Volunteer = new Volunteer
            {
                FullName = this.FirstNameEntry.Text + " " + this.LastNameEntry.Text,
                Department = this.DepartmentPicker.SelectedItem.ToString(),
                Phone = this.PhoneNoEntry.Text,
                Email = this.EmailEntry.Text
            };
        }
    }
}