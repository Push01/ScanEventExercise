using Moq;
using ScanEventExercise.Process;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScanEventExercise.UnitTests
{
    public class ScanEventsProcessTest
    {
        private readonly Mock<ILogger> _mockLogger;
        private ScanEventsProcess _scanEventsProcess;

        public ScanEventsProcessTest()
        {
            _mockLogger = new Mock<ILogger> ();
            _scanEventsProcess = new ScanEventsProcess(_mockLogger.Object);
        }

        [Fact]
        public async Task ProcessScanEventsAsync_WithInvalidScanEventServiceUrl_LogsInvalidUriError()
        {
            await _scanEventsProcess.ExecuteScanEventsAsync("testUrl");
            _mockLogger.Verify(x => x.Error("GET Exception: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set."), Times.Once);
        }       
    }
}

