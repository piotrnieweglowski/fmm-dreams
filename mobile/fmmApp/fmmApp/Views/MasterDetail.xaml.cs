using fmmApp.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : ContentPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            this.BindingContext = NavigationDataService.Instance.NavigationViewModel;
        }
    }
}