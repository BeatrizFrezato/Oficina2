using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesRepositorio
{
    public interface IProfessorRepositorio
    {
        IEnumerable<ProfessorModel> GetAllProfessores();
        ProfessorModel? GetProfessorById(int id);
        void AdicionarProfessor(ProfessorModel professor);
        void DeleteProfessor(int id);
        void AlterarProfessor(int id, ProfessorModel professor);
    }
}
