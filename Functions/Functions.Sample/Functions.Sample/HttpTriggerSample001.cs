using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var name = req.Query["name"].ToString();
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic? data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            return name != null ? new OkObjectResult($"Welcome to Azure Functions! {name}.") : new BadRequestObjectResult($"Please pass a name on the query string or in the request Body");
        }
    }
}
