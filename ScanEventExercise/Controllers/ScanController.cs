using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using ScanEventExercise.Model;
using Serilog;

namespace ScanEventExercise.Controllers
{
    [ApiController]
    [Route("v1/scan/scanevents")]
    public class ScanController : ControllerBase
    {
        private readonly ILogger _logger;
        private string RunningMessage() => $"apiCommand: ";

        public ScanController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ScanEventRoot GetScanEvents(int FromEventId , int Limit)
        {
            var webclient = new WebClient();
            var json = webclient.DownloadString(".\\Data\\scanevents.json");
            var scanEventRoot = JsonConvert.DeserializeObject<ScanEventRoot>(json);
            return scanEventRoot;
        }
    }
}
