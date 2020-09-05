using fmmApp.Models;
using fmmApp.Models.Navigation;
using fmmApp.ViewModels.Forms;
using Syncfusion.XForms.ProgressBar;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views.Forms
{
    /// <summary>
    /// Page to add business details such as name, email address, and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDreamPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddDreamPage" /> class.
        /// </summary>
        public AddDreamPage()
        {
            InitializeComponent();
            
        }
        
    }
}