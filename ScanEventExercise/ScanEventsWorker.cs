using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ScanEventExercise.Helper;
using ScanEventExercise.Model;
using ScanEventExercise.Process;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace ScanEventExercise
{
    public class ScanEventsWorker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IScanEventsProcess _scanEventsProcess;
        private readonly WorkerOption _options;

        public ScanEventsWorker(ILogger logger, WorkerOption options)
        {
            _logger = logger;
            _options = options;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Starting ScanEventsWorker service");
            return Task.CompletedTask;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _scanEventsProcess.ExecuteScanEventsAsync(_options.ScanEventServiceUrl);
                await Task.Delay(1000, stoppingToken);
            }
        }
       
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Stopping ScanEventsWorker service");
            return Task.CompletedTask;
        }

    }
}
