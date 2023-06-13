using System.Text.Json;

namespace NS2_VS.Services
{
    public interface ICrawlerService
    {
        public Task<JsonDocument> GetPlayerComparison(Array playerIds);

    }
}
