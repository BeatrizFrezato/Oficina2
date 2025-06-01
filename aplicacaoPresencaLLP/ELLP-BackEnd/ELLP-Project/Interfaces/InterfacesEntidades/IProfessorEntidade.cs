using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IProfessorEntidade
    {
        void AlterarNome(string nome);
        void AdicionarOficina(OficinaModel oficina);
        void RemoverOficina(int oficinaId);
    }
}
