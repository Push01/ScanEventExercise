using System.Threading.Tasks;

namespace ScanEventExercise.Process
{
    public interface IScanEventsProcess
    {
        Task ExecuteScanEventsAsync(string ScanEventServiceUrl);
    }
}
