using fmmApp.Models;
using fmmApp.Models.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmmApp.Services
{
    public class CategoriesDataStore : IDataStore<Category>
    {
        private readonly FmmClient _client;
        readonly List<Category> _categories;

        public CategoriesDataStore(FmmClient client)
        {
            _client = client;
            _categories = new List<Category>();
        }

        public async Task<bool> AddItemAsync(Category category)
        {
            await _client.Create(category);
            _categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category category)
        {
            var oldItem = _categories.Where((Category arg) => arg.Id == category.Id).FirstOrDefault();
            await _client.Update(category);
            _categories.Remove(oldItem);
            _categories.Add(category);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = _categories.Where((Category arg) => arg.Id == id.ToString()).FirstOrDefault();
            await _client.Delete<Category>(id.ToString());
            _categories.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetItemAsync(Guid id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(s => s.Id == id.ToString()));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            _categories.AddRange(await _client.Get<Category>());
            return await Task.FromResult(_categories);
        }

    }
}
