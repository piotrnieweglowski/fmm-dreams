using fmmApp.Models;
using fmmApp.ViewModels;
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

    }
}