using fmmApp.DataService;
using fmmApp.Models;
using fmmApp.Validations;
using fmmApp.Views.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace fmmApp.ViewModels
{
    public class AddSponsorViewModel : BaseViewModel
    {
        public AddSponsorViewModel()
        {
            Sponsor = new Sponsor();
            BackCommand = new Command(GoToSponsorListPage);
            CancelCommand = new Command(GoToSponsorListPage);
            AddSponsorCommand = new Command(async() => await AddSponsor());
            _name = new ValidatableObject<string>();
            AddValidations();
        }

        private ValidatableObject<string> _name;

        public Sponsor Sponsor { get; set; }


        public ValidatableObject<string> Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => _name);
            }
        }

        public ICommand ValidateNameCommand => new Command(() => ValidateName());

        public Command BackCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command AddSponsorCommand { get; set; }

        private bool Validate()
        {
            bool isValidName = ValidateName();


            return isValidName;
        }

        private bool ValidateName()
        {
            return _name.Validate();
        }

        private void AddValidations()
        {
            _name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A name is required." });

        }

        private void GoToSponsorListPage()
        {
            App.Current.MainPage = new SponsorsListPage();
        }

        private async Task AddSponsor()
        {
            await SponsorsListDataService.Instance.SaveNewSponsor(Sponsor);
            GoToSponsorListPage();
        }
    }
}
