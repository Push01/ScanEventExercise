using Newtonsoft.Json;
using ScanEventExercise.Model;
using Serilog;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScanEventExercise.Process
{
    public class ScanEventsProcess : IScanEventsProcess
    {
        private readonly ILogger _logger;
        public ScanEventsProcess(ILogger logger)
        {
            _logger = logger;
        }

        public async Task ExecuteScanEventsAsync(string ScanEventServiceUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync($"{ScanEventServiceUrl}").Result.Content.ReadAsStringAsync();
                    LogLatestScanEvents(result);

                }
            }
            catch (Exception e)
            {
                _logger.Error($"GET Exception: {e.Message}");
            }
        }

        private void LogLatestScanEvents(string jsonResult)
        {
            try
            {
                ScanEventRoot scanEventList = JsonConvert.DeserializeObject<ScanEventRoot>(jsonResult);
                var filteredScanEventList = scanEventList.ScanEvents
                        .GroupBy(p => p.ParcelId)
                        .Select(s => s
                        .OrderByDescending(d => d.CreatedDateTimeUtc)
                        .First())
                        .ToList();
                foreach (var ScanEvent in filteredScanEventList)
                {
                    _logger.Information("ScanEvents - EventId:{EventId}, ParcelId:{ParcelId}, Type:{Type}, CreatedDateTimeUtc:{CreatedDateTimeUtc}, StatusCode:{StatusCode}, RunId:{RunId}",
                        ScanEvent.EventId, ScanEvent.ParcelId, ScanEvent.Type,
                        ScanEvent.CreatedDateTimeUtc, ScanEvent.StatusCode, ScanEvent.User.RunId);
                }

            }
            catch (Exception e)
            {
                _logger.Error($"GET Exception: {e.Message}");
            }
        }

    }
}
