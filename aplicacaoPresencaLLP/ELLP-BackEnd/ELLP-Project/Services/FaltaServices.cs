using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesServices;
using ELLP_Project.Persistence.Repositorios;

namespace ELLP_Project.Services
{
    public class FaltaServices : IFaltaServices
    {
        private readonly FaltaRepositorio _faltaRepositorio;
        private readonly AlunoRepositorio _alunoRepositorio;

        public FaltaServices(FaltaRepositorio faltaRepositorio, AlunoRepositorio alunoRepositorio)
        {
            _faltaRepositorio = faltaRepositorio;   
            _alunoRepositorio = alunoRepositorio;   
        }

        public FaltaModel AtualizarFalta(int FaltaId, FaltaModel falta)
        {
            if (_faltaRepositorio.GetFaltaById(FaltaId) == null)
                throw new ArgumentException("Não foi encontrado nenhuma falta com esse ID.");
            if (falta.DataFalta == null)
                falta.DataFalta = _faltaRepositorio.GetFaltaById(FaltaId).DataFalta;

            return _faltaRepositorio.AtualizarFalta(FaltaId, falta);
        }

        public FaltaModel CadastrarFalta(FaltaModel falta)
        {
            falta.Aluno = _alunoRepositorio.GetAlunoById(falta.AlunoId);
            if (falta.Aluno == null)
                throw new ArgumentException("Não existe aluno com o ID informado");
            if (falta.DataFalta == null)
                throw new ArgumentException("Data não preenchida");

            return _faltaRepositorio.AdicionarFalta(falta);
        }

        public FaltaModel? GetFaltaById(int faltaId)
        {
            if (_faltaRepositorio.GetFaltaById(faltaId) == null)
                throw new ArgumentException("Não existe falta com esse ID");
            return _faltaRepositorio.GetFaltaById(faltaId);
        }

        public IEnumerable<FaltaModel> GetFaltas()
        {
            return _faltaRepositorio.GetAllFaltas();
        }

        public List<FaltaModel> GetFaltasByAluno(int alunoId)
        {
            if (_alunoRepositorio.GetAlunoById(alunoId) == null)
                throw new ArgumentException("Não existe aluno com esse ID.");
            return _faltaRepositorio.GetFaltaByAluno(alunoId);
        }

        public bool RemoverFalta(int faltaId)
        {
            if(_faltaRepositorio.GetFaltaById(faltaId)==null)
                throw new ArgumentException("Não existe falta com esse ID.");
            return _faltaRepositorio.RemoverFalta(faltaId); 
        }
    }
}
