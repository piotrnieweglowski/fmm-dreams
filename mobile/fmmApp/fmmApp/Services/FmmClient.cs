using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fmmApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace fmmApp.Services
{
    public class FmmClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _jsonSerializer;

        public FmmClient(HttpClient httpClient, JsonSerializer jsonSerializer)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentException(nameof(jsonSerializer));
        }

        public async Task<List<T>> Get<T>() where T : ResourceItem<T>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ResourceItem<T>.ResourcePath);
            using (var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            {
                result.EnsureSuccessStatusCode();
                using (var responseStream = await result.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        return _jsonSerializer.Deserialize<List<T>>(jsonTextReader);      
                    }
                }
            }
        }

        public async Task<T> Get<T>(string id) where T : ResourceItem<T>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ResourceItem<T>.CreatePathWithId(id));
            using (var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            {
                result.EnsureSuccessStatusCode();
                using (var responseStream = await result.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        return _jsonSerializer.Deserialize<T>(jsonTextReader);
                    }
                }
            }
        }

        public async Task Create<T>(T item) where T : ResourceItem<T>
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, ResourceItem<T>.ResourcePath))
            using (var content = CreateStreamContent(item))
            {
                request.Content = content;

                using (var response = await _httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task Update<T>(T item) where T : ResourceItem<T>
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, item.ResourcePathWithId))
            using (var content = CreateStreamContent(item))
            {
                request.Content = content;

                using (var response = await _httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public async Task Delete<T>(string id) where T : ResourceItem<T>
        {
            using (var request = new HttpRequestMessage(HttpMethod.Delete, ResourceItem<T>.CreatePathWithId(id)))
            {
                using (var response = await _httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        private static HttpContent CreateStreamContent(object content)
        {
            HttpContent httpContent = null;
            if (content != null)
            {
                var memoryStrem = new MemoryStream();
                SerializeJsonIntoStream(content, memoryStrem);
                memoryStrem.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(memoryStrem);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        private static void SerializeJsonIntoStream(object value, Stream stream)
        {
            const int BufferSize = 1024;
            using (var streamWriter = new StreamWriter(stream, new UTF8Encoding(false), BufferSize, true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                var serializer = new JsonSerializer();
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializer.Serialize(jsonTextWriter, value);
                jsonTextWriter.Flush();
            }
        }
    }
}