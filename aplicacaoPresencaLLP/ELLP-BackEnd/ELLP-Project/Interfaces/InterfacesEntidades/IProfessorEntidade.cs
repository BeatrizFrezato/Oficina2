using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IProfessorEntidade
    {
        void AlterarNome(string nome);
        void AlterarSenha(string senha);
        void AlterarLogin(string login);
        void AdicionarOficina(OficinaModel oficina);
        void RemoverOficina(int oficinaId);
    }
}
