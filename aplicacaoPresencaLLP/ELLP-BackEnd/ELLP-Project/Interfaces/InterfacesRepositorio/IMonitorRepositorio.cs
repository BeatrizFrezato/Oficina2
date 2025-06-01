using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesRepositorio
{
    public interface IMonitorRepositorio
    {
        IEnumerable<MonitorModel> GetAllMonitor();
        MonitorModel? GetMonitorById(int id);
        void AdicionarMonitor(MonitorModel monitor);
        void AlterarMonitor(int monitorId,MonitorModel monitor);
        void DeleteMonitor(int monitorId);
    }
}
