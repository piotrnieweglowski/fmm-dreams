using fmmApp.Models.SponsorDetail;
using fmmApp.Validations;
using fmmApp.Views.Navigation;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using fmmApp.Views.SponsorDetail;

namespace fmmApp.ViewModels
{
    public class EditSponsorViewModel : BaseViewModel
    {
        public EditSponsorViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
        }
        public EditSponsorViewModel(Sponsor sponsor = null)
        {
            Name = sponsor.Name;
            EmailAddress = sponsor.EmailAddress;
            PhoneNumber = sponsor.ContactNumber;
            AdditionalInfo = sponsor.AdditionalInfo;
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

        private void BackButtonClicked(object obj)
        {
            App.Current.MainPage = new SponsorDetailPage();
        }
    }
}
