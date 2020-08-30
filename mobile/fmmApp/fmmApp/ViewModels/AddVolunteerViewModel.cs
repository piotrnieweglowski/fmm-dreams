using Xamarin.Forms;
using fmmApp.Models.Detail;
using System.Collections.ObjectModel;

using fmmApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace fmmApp.ViewModels
{
    public class AddVolunteerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        List<Department> departmentList;
        public List<Department> DepartmentList
        {
            get { return departmentList; }
            set
            {
                if (departmentList != value)
                {
                    departmentList = value;
                    OnPropertyChanged();
                }
            }
        }

        Department selectedDepartment;
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                if (selectedDepartment != value)
                {
                    selectedDepartment = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public AddVolunteerViewModel()
        {
           
        }
    }
}
