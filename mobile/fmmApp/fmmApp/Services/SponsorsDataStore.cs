using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fmmApp.Models;

namespace fmmApp.Services
{
    public class SponsorsDataStore : IDataStore<Sponsor>
    {
        private readonly FmmClient _client;
        readonly List<Sponsor> _sponsors;

        public SponsorsDataStore(FmmClient client)
        {
            _client = client;
            _sponsors = new List<Sponsor>();
        }

        public async Task<bool> AddItemAsync(Sponsor sponsor)
        {
            await _client.Create(sponsor);
            _sponsors.Add(sponsor);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Sponsor sponsor)
        {
            var oldItem = _sponsors.Where((Sponsor arg) => arg.Id == sponsor.Id).FirstOrDefault();
            await _client.Update(sponsor);
            _sponsors.Remove(oldItem);
            _sponsors.Add(sponsor);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = _sponsors.Where((Sponsor arg) => arg.Id == id.ToString()).FirstOrDefault();
            await _client.Delete<Sponsor>(id.ToString());
            _sponsors.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Sponsor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(_sponsors.FirstOrDefault(s => s.Id == id.ToString()));
        }

        public async Task<IEnumerable<Sponsor>> GetItemsAsync(bool forceRefresh = false)
        {
            _sponsors.AddRange(await _client.Get<Sponsor>());
            return await Task.FromResult(_sponsors);
        }
    }
}