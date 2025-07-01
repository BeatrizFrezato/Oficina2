using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesServices;
using ELLP_Project.Persistence.Repositorios;

namespace ELLP_Project.Services
{
    public class OficinaServices : IOficinaServices
    {

        private readonly OficinaRepositorio _oficinaRepositorio;
        private readonly ProfessorRepositorio _professorRepositorio;

        public OficinaServices(OficinaRepositorio oficinaRepositorio, ProfessorRepositorio professorRepositorio)
        {
            _oficinaRepositorio = oficinaRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public OficinaModel AtualizarOficina(int OficinaId, OficinaModel oficina)
        {
            OficinaModel oficinaAtual = _oficinaRepositorio.GetOficinaById(OficinaId);
            if(oficinaAtual == null)
            {
                throw new ArgumentException("Não existe oficina com esse ID");
            }

            if (string.IsNullOrWhiteSpace(oficina.OficinaNome))
            {
                throw new ArgumentException("O campo nome não pode estar vazio.");
            }

            if (_professorRepositorio.GetProfessorById(oficina.ProfessorId) == null)
            {
                throw new ArgumentException("Não é possível criar uma oficina sem um professor vinculado");
            }

            oficina.Professor = _professorRepositorio.GetProfessorById(oficina.ProfessorId);

            return _oficinaRepositorio.AtualizarOficina(OficinaId, oficina);
        }

        public OficinaModel CadastrarOficina(OficinaModel oficina)
        {
            if (string.IsNullOrWhiteSpace(oficina.OficinaNome))
            {
                throw new ArgumentException("O campo nome não pode estar vazio.");
            }

            if (_professorRepositorio.GetProfessorById(oficina.ProfessorId) == null)
            {
                throw new ArgumentException("Não é possível criar uma oficina sem um professor vinculado");
            }

            oficina.Professor = _professorRepositorio.GetProfessorById(oficina.ProfessorId);

            return _oficinaRepositorio.AdicionarOficina(oficina);
        }

        public OficinaModel? GetOficinaById(int oficinaId)
        {
            return _oficinaRepositorio.GetOficinaById(oficinaId);
        }

        public IEnumerable<OficinaModel> GetOficinas()
        {
            return _oficinaRepositorio.GetAllOficinas();
        }

        public bool RemoverAlunoMatriculado(int oficinaId, int alunoId)
        {
            OficinaModel oficina = _oficinaRepositorio.GetOficinaById(oficinaId);
            if(oficina == null)
            {
                throw new ArgumentException("Não existe oficina com esse nome.");
            }

            oficina.
        }

        public bool RemoverOficina(int oficinaId)
        {
            return _oficinaRepositorio.DeleteOficina(oficinaId);
        }
    }
}
