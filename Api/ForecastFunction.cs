using System;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class ForecastFunction
    {
        private static string GetSummary(int count)
        {
            Console.WriteLine("Count: " + count);
            var feeling = "Excited";

            if (count >= 3000)
            {
                Console.WriteLine("Count more than 3000");
                feeling = "Hold my beer";
            }
            else if (count >= 1500 && count < 2500)
            {
                feeling = "We are almost there";
            }
            else if (count >= 2500 && count < 3000)
            {
                feeling = "We are conquering the world";
            }
            else if (count <= 1500)
            {
                feeling = "We have to step up the gas";
            }

            return feeling;
        }


        [FunctionName("PayslipCount")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var randomNumber = new Random();
            var count = 0;

            var result = Enumerable.Range(1, 5).Select(index => new Forecast
            {
                Date = DateTime.Now.AddMonths(index-1).ToString("MMMM"),
                PayslipIncrease = count = ((randomNumber.Next(12, 35) *100) ),
                Feeling = GetSummary(count)
            }).ToArray();

            return new OkObjectResult(result);
        }
    }
}
