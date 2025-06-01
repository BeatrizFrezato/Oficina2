using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesServices
{
    public interface IProfessorServices
    {
        void CadastrarProfessor(ProfessorModel professor);
        bool AtualizarProfessor(ProfessorModel professor);
        bool RemoverProfessor(int professorId);
        IEnumerable<ProfessorModel> GetProfessores();
        ProfessorModel? GetProfessorById(int professorId);
    }
}
