using Xamarin.Forms;
using fmmApp.Models;
using fmmApp.Models.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using fmmApp.Views.Navigation;
using System.Threading.Tasks;

namespace fmmApp.ViewModels
{
    public class AddVolunteerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Volunteer Volunteer { get; set; }

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

        public Command AddVolunteerCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command BackCommand { get; set; }

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
            Volunteer = new Volunteer();
            BackCommand = new Command(GoToVolunteerListPage);
            CancelCommand = new Command(GoToVolunteerListPage);
            AddVolunteerCommand = new Command(async () => AddVolunteer());
        }

        private void GoToVolunteerListPage()
        {
            App.Current.MainPage = new VolunteerListPage();
        }

        private async Task AddVolunteer()
        {
            GoToVolunteerListPage();
        }
    }
}
