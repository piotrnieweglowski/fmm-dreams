using System.Reflection;
using System.Runtime.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using fmmApp.Models;
using fmmApp.Services;
using fmmApp.ViewModels.Navigation;
using Xamarin.Forms.Internals;

namespace fmmApp.DataService
{
    [Preserve(AllMembers = true)]
    public class NavigationDataService
    {
        #region fields

        private static NavigationDataService instance;

        private NavigationViewModel navigationViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="NavigationDataService"/>.
        /// </summary>
        public static NavigationDataService Instance => instance ?? (instance = new NavigationDataService());

        /// <summary>
        /// Gets or sets the value of navigation page view model.
        /// </summary>
        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        public async Task<NavigationViewModel> PopulateData()
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Dreamer>>();
            var navigationModels = await service.GetItemsAsync();
            var viewModel = new NavigationViewModel();
            viewModel.NavigationList = new System.Collections.ObjectModel.ObservableCollection<Models.Navigation.NavigationModel>();
            foreach (var navigationModel in navigationModels)
            {
                viewModel.NavigationList.Add(new Models.Navigation.NavigationModel { ItemName = navigationModel.FirstName });
            }

            return viewModel;
        }

        #endregion
    }
}