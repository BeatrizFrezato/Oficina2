using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;
using ELLP_Project.Persistence.Interfaces.InterfacesServices;
using ELLP_Project.Persistence.Repositorios;

namespace ELLP_Project.Services
{
    public class AlunoServices : IAlunoServices
    {

        private readonly AlunoRepositorio _alunoRepositorio;
        private readonly OficinaRepositorio _oficinaRepositorio;

        public AlunoServices(AlunoRepositorio alunoRepositorio, OficinaRepositorio oficinaRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _oficinaRepositorio = oficinaRepositorio;

        }

        public AlunoModel AtualizarAluno(int alunoId, AlunoModel aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.AlunoNome))
                throw new ArgumentException("Nome do aluno é obrigatório.");

            if (_alunoRepositorio.GetAlunoById(alunoId) == null)
                throw new ArgumentException("Não existe aluno com o ID informado");

            if (aluno.AlunoOficinas == null)
            {
                aluno.AlunoOficinas = _oficinaRepositorio.GetOficinaById(aluno.OficinaId);
            }

            return _alunoRepositorio.AtualizarAluno(alunoId, aluno);
        }
            
        public AlunoModel CadastrarAluno(AlunoModel aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.AlunoNome))
                throw new ArgumentException("Nome do aluno é obrigatório");

            return _alunoRepositorio.AdicionarAluno(aluno);     
        }

        public AlunoModel? GetAlunoById(int alunoId)
        {
            return _alunoRepositorio.GetAlunoById(alunoId);
        }

        public IEnumerable<AlunoModel> GetAlunos()
        {
            return _alunoRepositorio.GetAllAlunos();
        }

        public bool RemoverAluno(int alunoId)
        {
            return _alunoRepositorio.DeleteAluno(alunoId);
        }
    }
}
