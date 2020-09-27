using System.Reflection;
using System.Runtime.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using fmmApp.Models;
using fmmApp.Services;
using fmmApp.ViewModels.Navigation;
using Xamarin.Forms.Internals;
using fmmApp.ViewModels.Detail;
using fmmApp.Models.Navigation;

namespace fmmApp.DataService
{
    [Preserve(AllMembers = true)]
    public class DreamerListDataService
    {
        #region fields

        private static DreamerListDataService instance;

        private DreamerListViewModel dreamerListViewModel;

        #endregion

        #region Properties

        public static DreamerListDataService Instance => instance ?? (instance = new DreamerListDataService());



        #endregion

        #region Methods

        public async Task<DreamerListViewModel> PopulateData()
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Dreamer>>();
            var dreamerModels = await service.GetItemsAsync();
            var viewModel = new DreamerListViewModel();
            viewModel.DreamerList = new System.Collections.ObjectModel.ObservableCollection<Models.Navigation.DreamerModel>();
            foreach (var dreamerModel in dreamerModels)
            {
                viewModel.DreamerList.Add(new Models.Navigation.DreamerModel { Name = dreamerModel.FirstName });
            }

            return viewModel;
        }

        #endregion
    }
}