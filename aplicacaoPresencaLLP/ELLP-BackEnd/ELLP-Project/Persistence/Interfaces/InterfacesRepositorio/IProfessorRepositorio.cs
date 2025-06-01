using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesRepositorio
{
    public interface IProfessorRepositorio
    {
        IEnumerable<ProfessorModel> GetAllProfessores();
        ProfessorModel? GetProfessorById(int id);
        void AdicionarProfessor(ProfessorModel professor);
        bool DeleteProfessor(int id);
        bool AlterarProfessor(int id, ProfessorModel professor);
    }
}
