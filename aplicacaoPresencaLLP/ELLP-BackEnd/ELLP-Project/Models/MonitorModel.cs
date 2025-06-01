using ELLP_Project.Persistence.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class MonitorModel : IMonitorEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public OficinaModel Oficina { get; set; }
        public string Salt { get; set; }
        public string SenhaHash { get; set; }
        public string Login { get; set; }

        public void AdicionarOficina(OficinaModel oficina)
        {
            Oficina = oficina;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void DefinirSenhaHash(string senhaHash)
        {
            SenhaHash = senhaHash;
        }

        public void DefinirSalt(string salt)
        {
            Salt = salt;
        }

        public void DefinirLogin(string login)
        {
            Login = login;
        }
    }
}
