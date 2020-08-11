using fmmApp.DataService;
using Syncfusion.XForms.Backdrop;
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
    public partial class BackdropPage : SfBackdropPage
    {
        private BackdropBackLayer BackLayer;

        public BackdropPage()
        {
            this.BindingContext = NavigationDataService.Instance.NavigationViewModel;
            this.IsBackLayerRevealed = true;
            InitializeComponent();
            this.BackLayer = new BackdropBackLayer

            {
                Content = new StackLayout
                {

                }
            };
            this.FrontLayer = new BackdropFrontLayer()
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new ListView
                        {
                            ItemsSource = new string[] { "Ustawienia", "Region", "Dodaj Marzyciela" ,"Dodaj Marzenie"}
                        }
                    }
                }
            };
        }

    }
}