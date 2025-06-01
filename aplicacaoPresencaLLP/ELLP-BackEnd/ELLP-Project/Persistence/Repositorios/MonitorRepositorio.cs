using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ELLP_Project.Persistence.Repositorios
{
    public class MonitorRepositorio : IMonitorRepositorio
    {
        private readonly List<MonitorModel> _monitores = new List<MonitorModel>();

        public void AdicionarMonitor(MonitorModel monitor)
        {
            _monitores.Add(monitor);
        }

        public bool AlterarMonitor(int monitorId, MonitorModel monitor)
        {
            MonitorModel getMonitor = _monitores.FirstOrDefault(monitor => monitor.Id == monitorId);
            if (getMonitor == null)
                return false;

            getMonitor.AlterarNome(monitor.Nome);
            getMonitor.AdicionarOficina(monitor.Oficina);
            if (monitor.Salt != null && getMonitor.Salt != monitor.Salt)
            {
                getMonitor.DefinirSalt(monitor.Salt);
            }
            if (monitor.SenhaHash != null && getMonitor.SenhaHash != monitor.SenhaHash)
            {
                getMonitor.DefinirSenhaHash(monitor.SenhaHash);
            }
            if (getMonitor.Login != monitor.Login)
            {
                getMonitor.DefinirLogin(monitor.Login);
            }

            return true;
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
