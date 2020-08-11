using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fmmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMaster : ContentPage
    {
        public ListView ListView;

        public MasterMaster()
        {
            InitializeComponent();

            BindingContext = new MasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMasterMenuItem> MenuItems { get; set; }

            public MasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMasterMenuItem>(new[]
                {
                    new MasterMasterMenuItem { Id = 0, Title = "Ustawienia" },
                    new MasterMasterMenuItem { Id = 1, Title = "Region" },
                    new MasterMasterMenuItem { Id = 2, Title = "Dodaj Marzyciela" },
                    new MasterMasterMenuItem { Id = 3, Title = "Dodaj Marzenie" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}