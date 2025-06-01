using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IOficinaEntidade
    {
        void AlterarNomeOficina(string nome);
        void RemoverAlunoOficina(int AlunoId);
        void RemoverMonitorOficina(int  MonitorId);
        void AlterarProfessorOficina(ProfessorModel professor);
        void RemoverProfessorOficina(int professorId);
        void AdicionarProfessorOficina(ProfessorModel professor);

    }
}
