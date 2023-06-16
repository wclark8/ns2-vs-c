using Microsoft.AspNetCore.Mvc;
using NS2_VS.Services;
using System.Collections;
using System.Text.Json;

namespace NS2_VS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NS2VSController : ControllerBase
    {
        private ICrawlerService _crawlerService;
        private readonly ILogger<NS2VSController> _logger;
        private IPlayerComparisonService _playerComparisonService;
        public NS2VSController(ILogger<NS2VSController> logger, ICrawlerService crawlerService,
            IPlayerComparisonService playerComparisonService)
        {
            _logger = logger;
            _crawlerService = crawlerService;
            _playerComparisonService = playerComparisonService;
        }
        //Task<JsonDocument> stub
        [HttpPost(Name = "GetPlayerComparison")]
        public async void Post(string playerOneId, string playerTwoId)
        {

            try
            {
                string[] playerIds = new string[2] { playerOneId, playerTwoId };

                var crawlerResult = await _crawlerService.GetPlayerComparison(playerIds);

                try
                {
                    //explicit for clarity
                    Player[] crawlerResults = JsonSerializer.Deserialize<Player[]>(crawlerResult);

                    // process crawler results
                    _playerComparisonService.ProcessPlayerComparison(crawlerResults);                

                } catch (JsonException e)
                {
                    _logger.LogError(e.ToString());
                    throw;
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
