using AzureTableStorage.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAzureTableClient _azureTableClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAzureTableClient azureTableClient)
        {
            _logger = logger;
            _azureTableClient = azureTableClient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cloudtable = _azureTableClient.CreateIfNotExists("TestEntities");
            TestEntity testEntity = new TestEntity("sinha", "arkaprava.123040@gmail1.com")
            {
                MobileNumber = 961475,
                Id = 101,
                ETag="*"
            };
            //cloudtable.InsertOrMergeEntity<TestEntity>(testEntity);

            var cloudTableEntity = cloudtable.RetrieveEntityUsingPointQuery<TestEntity>("sinha", "arkaprava.123040@gmail.com");

            //cloudtable.DeleteEntity(testEntity);
            return Ok();
        }
    }
}
