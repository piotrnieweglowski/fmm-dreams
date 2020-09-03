using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Text;

namespace fmmApp.Models
{
    public class Step
    {
        public string Description { get; set; }
        public StepStatus Status { get; set; }
        public int ProgressValue { get; set; }
    }
}
