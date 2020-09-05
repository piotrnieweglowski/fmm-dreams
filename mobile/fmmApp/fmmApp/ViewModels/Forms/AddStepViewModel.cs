using fmmApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace fmmApp.ViewModels.Forms
{
    public class AddStepViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public int ProgressValue { get; set; }
        public string TaskDescription { get; set; }

        public AddStepViewModel()
        {

        }

    }
}
