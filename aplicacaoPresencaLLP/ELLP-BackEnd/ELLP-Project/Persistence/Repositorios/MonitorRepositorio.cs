using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ELLP_Project.Persistence.Repositorios
{
    public class MonitorRepositorio : IMonitorRepositorio
    {
        private readonly List<MonitorModel> _monitores = new List<MonitorModel>();

        public MonitorModel AdicionarMonitor(MonitorModel monitor)
        {
            _monitores.Add(monitor);
            return monitor;
        }

        public MonitorModel AlterarMonitor(int monitorId, MonitorModel monitor)
        {
            MonitorModel getMonitor = _monitores.FirstOrDefault(monitor => monitor.Id == monitorId);
            if (getMonitor == null)
                return null;
            getMonitor.AlterarNome(monitor.Nome);

            getMonitor.AdicionarOficina(monitor.Oficina);

            getMonitor.DefinirSalt(monitor.Salt);
            getMonitor.DefinirSenhaHash(monitor.SenhaHash);
            getMonitor.DefinirLogin(monitor.Login);

            return getMonitor;
        }

        public bool DeleteMonitor(int monitorId)
        {
            if(_monitores.FirstOrDefault(monitor=>monitor.Id == monitorId) == null)
                return false;
            _monitores.RemoveAll(monitor=>monitor.Id == monitorId);
            return true;
        }

        public IEnumerable<MonitorModel> GetAllMonitor()
        {
            return _monitores;
        }

        public MonitorModel? GetMonitorById(int id)
        {
            return _monitores.FirstOrDefault(monitor=>monitor.Id==id);
        }
    }
}
