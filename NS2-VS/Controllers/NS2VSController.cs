using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public NS2VSController(ILogger<NS2VSController> logger, ICrawlerService crawlerService)
        {
            _logger = logger;
            _crawlerService = crawlerService;
        }

        [HttpPost(Name = "GetPlayerComparison")]
        public async Task<JsonDocument> Post(string playerOneId, string playerTwoId)
        {

            try
            {
                string[] playerIds = new string[2] { playerOneId, playerTwoId };

                var crawlerResult = await _crawlerService.GetPlayerComparison(playerIds);

                //transform
                return crawlerResult;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
