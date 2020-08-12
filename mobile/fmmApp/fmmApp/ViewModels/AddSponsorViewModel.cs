using fmmApp.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace fmmApp.ViewModels
{
    public class AddSponsorViewModel : BaseViewModel
    {
        public AddSponsorViewModel()
        {
            _name = new ValidatableObject<string>();
            AddValidations();
        }

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

    }
}
