using Xamarin.Forms;
using fmmApp.Models.Detail;
using System.Collections.ObjectModel;

using fmmApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace fmmApp.ViewModels
{
    public class AddVolunteerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Department> DepartmentList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _department;
        public string Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    OnPropertyChanged();
                }
            }
        }

        private Department _selectedDepartment { get; set; }
        public Department SelectedCity
        {
            get { return _selectedDepartment; }
            set
            {
                if (_selectedDepartment != value)
                {
                    _selectedDepartment = value;
                    Department = "Selected City : " + _selectedDepartment.City;
                }
            }
        }
        public AddVolunteerViewModel()
        {
            this.DepartmentList = new ObservableCollection<Department>()
            {
                new Department
                {
                    Key=1,
                    City="Bydgoszcz"
                },
                 new Department
                {
                     Key=2,
                    City="Wwa"
                }
            };
        }
    }
}
