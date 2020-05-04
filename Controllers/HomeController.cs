using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrustingSelfSignedCertificates.Models;

namespace TrustingSelfSignedCertificates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fetch()
        {

            var request = WebRequest.Create("https://www.sourceflake.com/weatherdata.json");
            request.Method = "GET";
            request.ContentType = "application/json";
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream, Encoding.UTF8);

            string responseString = reader.ReadToEnd();

            // a synthetic delay
            Thread.Sleep(TimeSpan.FromSeconds(3));

            return Content(responseString, "application/json");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
