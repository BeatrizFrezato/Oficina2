using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {

        private readonly List<ProfessorModel> _professor = new();

        public ProfessorModel AdicionarProfessor(ProfessorModel professor)
        {
            _professor.Add(professor);
            return professor;
        }

        public ProfessorModel AlterarProfessor(int id, ProfessorModel professor)
        {
            ProfessorModel getProfessor = _professor.FirstOrDefault(p=> p.Id == id);
            if (getProfessor == null)
                return null;
            getProfessor.AlterarNome(professor.Nome);
            getProfessor.DefinirLogin(professor.Login);
            getProfessor.DefinirSalt(professor.Salt);
            getProfessor.DefinirSenhaHash(professor.SenhaHash);

            if (professor.Oficinas.Count != 0)
                getProfessor.Oficinas = professor.Oficinas.ToList();

            return getProfessor;
        }

        public bool DeleteProfessor(int id)
        {
            ProfessorModel getProfessor = _professor.FirstOrDefault(p => p.Id==id);
            if(getProfessor == null)
                return false;
            _professor.Remove(getProfessor);
            return true;
        }

        public IEnumerable<ProfessorModel> GetAllProfessores()
        {
            return _professor;
        }

        public ProfessorModel? GetProfessorById(int id)
        {
            return _professor.FirstOrDefault(p=> p.Id==id); 
        }
    }
}
