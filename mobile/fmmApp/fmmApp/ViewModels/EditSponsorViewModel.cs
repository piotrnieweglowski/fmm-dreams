using fmmApp.Models.SponsorDetail;
using fmmApp.Validations;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace fmmApp.ViewModels
{
    public class EditSponsorViewModel : BaseViewModel
    {
        /*
        public EditSponsorViewModel()
        {
            _name = new ValidatableObject<string>();
            AddValidations();
        }
        */
        public EditSponsorViewModel()
        {
            
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
        /*
        private ValidatableObject<string> _name;

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
        */
    }
}
