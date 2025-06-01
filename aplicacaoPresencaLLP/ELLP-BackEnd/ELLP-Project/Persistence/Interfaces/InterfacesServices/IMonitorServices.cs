using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesServices
{
    public interface IMonitorServices
    {
        void CadastrarMonitor(MonitorModel monitor);
        bool AtualizarMonitor(MonitorModel monitor);
        bool RemoverMonitor(int monitorId);
        IEnumerable<MonitorModel> GetMonitors();
        MonitorModel? GetMonitorById(int monitorId);
    }
}
