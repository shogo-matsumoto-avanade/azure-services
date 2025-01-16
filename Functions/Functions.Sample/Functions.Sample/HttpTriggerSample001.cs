using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Sample
{
    public class HttpTriggerSample001
    {
        private readonly ILogger<HttpTriggerSample001> _logger;

        public HttpTriggerSample001(ILogger<HttpTriggerSample001> logger)
        {
            _logger = logger;
        }

        [Function("HttpTriggerSample001")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
