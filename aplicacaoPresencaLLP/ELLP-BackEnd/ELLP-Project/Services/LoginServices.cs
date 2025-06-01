using ELLP_Project.Models;
using ELLP_Project.Interfaces.InterfacesRepositorio;
using ELLP_Project.Interfaces.InterfacesServices;
using System.Security.Cryptography;
using System.Text;

namespace ELLP_Project.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IMonitorRepositorio _monitorRepositorio;
        private readonly IProfessorRepositorio _professorRepositorio;

        public LoginServices(
            IAlunoRepositorio alunoRepositorio,
            IMonitorRepositorio monitorRepositorio,
            IProfessorRepositorio professorRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _monitorRepositorio = monitorRepositorio;
            _professorRepositorio = professorRepositorio;
        }

        public (bool sucesso, string perfil)? Autenticar(LoginModel login)
        {
            var aluno = _alunoRepositorio.GetAllAlunos()
                .FirstOrDefault(a => a.Login == login.Login);
            if (aluno != null && ValidarSenha(login.Senha, aluno.Salt, aluno.SenhaHash))
                return (true, "aluno");

            var monitor = _monitorRepositorio.GetAllMonitor()
                .FirstOrDefault(m => m.Login == login.Login);
            if (monitor != null && ValidarSenha(login.Senha, monitor.Salt, monitor.SenhaHash))
                return (true, "monitor");

            var professor = _professorRepositorio.GetAllProfessores()
                .FirstOrDefault(p => p.Login == login.Login);
            if (professor != null && ValidarSenha(login.Senha, professor.Salt, professor.SenhaHash))
                return (true, "professor");

            return null;
        }

        private bool ValidarSenha(string senhaDigitada, string salt, string senhaHashCorreta)
        {
            using var sha256 = SHA256.Create();
            var senhaComSalt = senhaDigitada + salt;
            var senhaBytes = Encoding.UTF8.GetBytes(senhaComSalt);
            var hashBytes = sha256.ComputeHash(senhaBytes);
            var hashDigitada = Convert.ToBase64String(hashBytes);
            return hashDigitada == senhaHashCorreta;
        }
    }
}