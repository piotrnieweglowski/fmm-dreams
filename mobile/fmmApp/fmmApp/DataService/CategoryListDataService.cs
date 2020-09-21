using System.Reflection;
using System.Runtime.Serialization.Json;
using fmmApp.ViewModels.Navigation;
using Xamarin.Forms.Internals;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using fmmApp.Models;
using fmmApp.Services;
using System;

namespace fmmApp.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CategoryListDataService
    {
        #region fields
        private static CategoryListDataService instance;

        private CategoryListViewModel categoryListViewModel;

        IDataStore<Category> _service = Startup.ServiceProvider.GetService<IDataStore<Category>>();
        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CategoryListDataService"/>.
        /// </summary>
        public static CategoryListDataService Instance => instance ?? (instance = new CategoryListDataService());

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>

        public async Task<CategoryListViewModel> PopulateData()
        {
            var service = Startup.ServiceProvider.GetService<IDataStore<Category>>();
            var categories = await service.GetItemsAsync();
            var viewModel = new CategoryListViewModel();
            viewModel.CategoryList = new System.Collections.ObjectModel.ObservableCollection<Models.Category>();
            foreach (var category in categories)
            {
                viewModel.CategoryList.Add(new Models.Category { 
                    Id = category.Id,
                    Description = category.Description });
            }

            return viewModel;
        }

        public async Task<bool> SaveNewCategory(Category category)
        {
            category.Id = Guid.NewGuid().ToString(); 
            return await _service.AddItemAsync(category);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            return await _service.UpdateItemAsync(category);
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            return await _service.DeleteItemAsync(Guid.Parse(category.Id));
        }

        public async Task<Category> GetCategory(Category category)
        {
            return await _service.GetItemAsync(Guid.Parse(category.Id));
        }

        #endregion
    }
}
