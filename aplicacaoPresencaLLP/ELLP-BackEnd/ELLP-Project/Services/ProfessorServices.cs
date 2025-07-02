using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesServices;
using ELLP_Project.Persistence.Repositorios;
using ELLP_Project.Utils;

namespace ELLP_Project.Services
{
    public class ProfessorServices : IProfessorServices
    {

        private readonly ProfessorRepositorio _professorRepositorio;

        public ProfessorServices(ProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public bool AtualizarLogin(int professorId, string login)
        {
            ProfessorModel professor = _professorRepositorio.GetProfessorById(professorId);
            
            if(professor == null)
            {
                throw new ArgumentException("Não existe professor com esse ID");
            }
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("O campo login não pode estar vazio.");
            }

            professor.Login = login;

            _professorRepositorio.AlterarProfessor(professorId, professor);

            return true;
        }

        public ProfessorModel AtualizarProfessor(int ProfessorId, ProfessorModel professor)
        {
            ProfessorModel professorAtual = _professorRepositorio.GetProfessorById(ProfessorId);
            if(professorAtual == null)
            {
                throw new ArgumentException("Não existe professor com esse ID");
            }

            if(professor.SenhaHash == null)
            {
                professor.SenhaHash = professorAtual.SenhaHash;
                professor.Salt = professorAtual.Salt;
            }

            if(professor.Login == null)
            {
                professor.Login = professorAtual.Login;
            }

            if (string.IsNullOrWhiteSpace(professor.Nome))
            {
                professor.Nome = professorAtual.Nome;
            }

            return _professorRepositorio.AlterarProfessor(ProfessorId, professor);
        }

        public bool AtualizarSenha(int professorId, string senha)
        {
            ProfessorModel professor = _professorRepositorio.GetProfessorById(professorId);
            if(professor == null)
            {
                throw new ArgumentException("Professor não existe.");
            }

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("O campo senha não pode estar vazio.");

            professor.Salt = PasswordUtils.CriarSalt();
            professor.SenhaHash = PasswordUtils.GerarHash(senha, professor.Salt);

            return true;
        }

        public ProfessorModel CadastrarProfessor(ProfessorModel professor)
        {
            if(professor.SenhaHash == null)
            {
                throw new ArgumentException("O campo senha não pode estar vazio.");
            }

            if(professor.Login== null)
            {
                throw new ArgumentException("O campo login não pode estar vazio.");
            }

            if (professor.Nome == null)
            {
                throw new ArgumentException("O campo nome não pode estar vazio.");
            }

            return _professorRepositorio.AdicionarProfessor(professor);
        }

        public ProfessorModel? GetProfessorById(int professorId)
        {
            if (_professorRepositorio.GetProfessorById(professorId) == null)
                throw new ArgumentException("Não existe professor com esse ID.");

            return _professorRepositorio.GetProfessorById(professorId);
        }

        public IEnumerable<ProfessorModel> GetProfessores()
        {
            return _professorRepositorio.GetAllProfessores();
        }

        public bool RemoverProfessor(int professorId)
        {
            if (_professorRepositorio.GetProfessorById(professorId) == null)
                throw new ArgumentException("Não existe professor com esse ID.");
            return _professorRepositorio.DeleteProfessor(professorId);
        }


    }
}
