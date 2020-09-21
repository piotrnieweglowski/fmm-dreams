using fmmApp.Models;
using fmmApp.Services;
using fmmApp.ViewModels.Navigation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace fmmApp.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SponsorsListDataService
    {
        #region fields 

        private static SponsorsListDataService instance;

        private SponsorsListViewModel sponsorsListViewModel;


        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="SponsorsListDataService"/>.
        /// </summary>
        public static SponsorsListDataService Instance => instance ?? (instance = new SponsorsListDataService());

        /// <summary>
        /// Gets or sets the value of icon name list page vi

        #endregion

        #region Methods

        public async Task<SponsorsListViewModel> PopulateData()
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Sponsor>>();
            var sponsors = await service.GetItemsAsync();
            var viewModel = new SponsorsListViewModel();
            viewModel.SponsorsList = new System.Collections.ObjectModel.ObservableCollection<Models.Navigation.SponsorModel>();
            foreach (var sponsor in sponsors)
            {
                viewModel.SponsorsList.Add(new Models.Navigation.SponsorModel { Name = sponsor.Name });
            }

            return viewModel;
        }

        public async Task<bool> SaveNewSponsor(Sponsor sponsor)
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Sponsor>>();
            sponsor.Id = Guid.NewGuid().ToString();
            return await service.AddItemAsync(sponsor);
        }

        public async Task<bool> UpdateSponsor(Sponsor sponsor)
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Sponsor>>();
            return await service.UpdateItemAsync(sponsor);
        }

        public async Task<bool> DeleteSponsor(Sponsor sponsor)
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Sponsor>>();
            return await service.DeleteItemAsync(Guid.Parse(sponsor.Id));
        }

        public async Task<Sponsor> GetSponsor(Sponsor sponsor)
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Sponsor>>();
            return await service.GetItemAsync(Guid.Parse(sponsor.Id));
        }
        #endregion

    }
}
