using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading;

namespace NS2_VS.Services
{
    public class CrawlerService : ICrawlerService
    {

        private readonly HttpClient _httpClient;
        private readonly string PLAYERSENDPOINT = "players";

        public CrawlerService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        // write dto
        public async Task<JsonDocument> GetPlayerComparison(Array playerIds)
        {
            //var serializer = new JsonSerializer();
            var request = CreateRequest(playerIds);
            using (var result = await _httpClient.PostAsync(_httpClient.BaseAddress + PLAYERSENDPOINT, request).ConfigureAwait(false))
            {
                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<JsonDocument>(contentStream).ConfigureAwait(false);
                }
            }
        }

        private HttpContent CreateRequest(Array playerIds)
        {
            var requestObject = new Dictionary<string, Array>() { { "playerIds", playerIds } };
            var json = JsonSerializer.Serialize(requestObject);
            var requestMessage = new StringContent(json.ToString(), System.Text.Encoding.UTF8, "application/json");

            return requestMessage;
        }
    }
}
