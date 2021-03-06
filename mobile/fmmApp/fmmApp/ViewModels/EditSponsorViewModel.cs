using fmmApp.Models;
using Xamarin.Forms;
using fmmApp.Views.SponsorDetail;
using System.Threading.Tasks;
using fmmApp.DataService;

namespace fmmApp.ViewModels
{
    public class EditSponsorViewModel : BaseViewModel
    {
        public Sponsor Sponsor { get; set; }

        public EditSponsorViewModel()
        {
            BackCommand = new Command(GoToSponsorDetailPage);
            CancelCommand = new Command(GoToSponsorDetailPage);
            SaveCommand = new Command(async () => await UpdateSponsor());
        }

        public EditSponsorViewModel(Sponsor sponsor)
        {
            Sponsor = sponsor;
            BackCommand = new Command(GoToSponsorDetailPage);
            CancelCommand = new Command(GoToSponsorDetailPage);
            SaveCommand = new Command(async () => await UpdateSponsor());
        }

        private string _name;

        private string _emailAddress;

        private string _additionalInfo;

        private string _phoneNumber;

        public string Name
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

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                RaisePropertyChanged(() => _emailAddress);
            }
        }

        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }
            set
            {
                _additionalInfo = value;
                RaisePropertyChanged(() => _additionalInfo);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged(() => _phoneNumber);
            }
        }

        public Command BackCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }

        private void GoToSponsorDetailPage()
        {
            App.Current.MainPage = new SponsorDetailPage();
        }

        private async Task UpdateSponsor()
        {
            //await SponsorsListDataService.Instance.Update(Sponsor);
            GoToSponsorDetailPage();
        }
        
    }
}
