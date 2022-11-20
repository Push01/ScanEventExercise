using Moq;
using ScanEventExercise.Helper;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScanEventExercise.UnitTests
{
    public class ScanEventsWorkerTest
    {
        private readonly Mock<ILogger> _mockLogger;
        private readonly Mock<WorkerOption> _mockOptions;

        public ScanEventsWorkerTest()
        {
            _mockLogger = new Mock<ILogger>();
            _mockOptions = new Mock<WorkerOption>();
        }
        [Fact]
        public async Task StartAsync_Success_LogsServiceStatingInfo()
        {

            var scanEventsWorker = new ScanEventsWorker(_mockLogger.Object, _mockOptions.Object);

            await scanEventsWorker.StartAsync(CancellationToken.None);

            _mockLogger.Verify(x => x.Information("Starting ScanEventsWorker service"), Times.Once);
        }


        [Fact]
        public async Task StartAsync_Success_LogsServiceStoppingInfo()
        {
            var scanEventsWorker = new ScanEventsWorker(_mockLogger.Object, _mockOptions.Object);

            await scanEventsWorker.StopAsync(CancellationToken.None);

            _mockLogger.Verify(x => x.Information("Stopping ScanEventsWorker service"), Times.Once);
        }

    }
}
