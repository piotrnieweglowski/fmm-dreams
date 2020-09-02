using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using fmmApp.Models;

namespace fmmApp.Services
{
    public class DreamersDataStore : IDataStore<Dreamer>
    {
        private readonly FmmClient _client;
        readonly List<Dreamer> _dreamers;

        public DreamersDataStore(FmmClient client)
        {
            _client = client;
            _dreamers = new List<Dreamer>();
        }

        public async Task<bool> AddItemAsync(Dreamer dreamer)
        {
            await _client.Create(dreamer);
            _dreamers.Add(dreamer);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Dreamer dreamer)
        {
            var oldItem = _dreamers.Where((Dreamer arg) => arg.Id == dreamer.Id).FirstOrDefault();
            await _client.Update(dreamer);
            _dreamers.Remove(oldItem);
            _dreamers.Add(dreamer);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = _dreamers.Where((Dreamer arg) => arg.Id == id.ToString()).FirstOrDefault();
            await _client.Delete<Dreamer>(id.ToString());
            _dreamers.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Dreamer> GetItemAsync(Guid id)
        {
            return await Task.FromResult(_dreamers.FirstOrDefault(s => s.Id == id.ToString()));
        }

        public async Task<IEnumerable<Dreamer>> GetItemsAsync(bool forceRefresh = false)
        {
            _dreamers.AddRange(await _client.Get<Dreamer>());
            return await Task.FromResult(_dreamers);
        }
    }
}