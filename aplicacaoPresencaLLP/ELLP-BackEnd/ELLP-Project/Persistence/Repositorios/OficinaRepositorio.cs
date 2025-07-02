using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios
{
    public class OficinaRepositorio : IOficinaRepositorio
    {

        private readonly List<OficinaModel> _oficina = new();

        public OficinaModel AdicionarOficina(OficinaModel oficina)
        {
            _oficina.Add(oficina);
            return oficina;
        }

        public OficinaModel AtualizarOficina(int oficinaId, OficinaModel oficina)
        {
            OficinaModel getOficina = _oficina.FirstOrDefault(f=> f.OficinaId == oficinaId);
            if (getOficina == null)
                return null;
            getOficina.AlterarNomeOficina(oficina.OficinaNome);
            getOficina.AlterarProfessorOficina(oficina.Professor);

            if(oficina.Alunos.Count!=0)
                getOficina.Alunos = oficina.Alunos.ToList();

            if(oficina.Monitores.Count!=0)
                getOficina.Monitores = oficina.Monitores.ToList();

            return getOficina;
        }

        public bool DeleteOficina(int oficinaId)
        {
            OficinaModel oficinaDelete = _oficina.FirstOrDefault(of=> of.OficinaId==oficinaId);
            if (oficinaDelete == null)
                return false;
            _oficina.Remove(oficinaDelete);
            return true;
        }

        public IEnumerable<OficinaModel> GetAllOficinas()
        {
            return _oficina;
        }

        public OficinaModel? GetOficinaById(int oficinaId)
        {
            return _oficina.FirstOrDefault(of => of.OficinaId == oficinaId);
        }

        public OficinaModel AlterarProfessor(int oficinaId, ProfessorModel professor)
        {
            OficinaModel oficina = _oficina.FirstOrDefault(of=> of.OficinaId== oficinaId);
            oficina.AlterarProfessorOficina(professor);
            return oficina;
        }

        public bool RemoverMonitor(int oficinaId, int monitorId)
        {
            return _oficina.FirstOrDefault(of=> of.OficinaId==oficinaId).RemoverMonitorOficina(monitorId);
        }
    }
}
