using ELLP_Project.Persistence.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class OficinaModel : IOficinaEntidade
    {
        public int OficinaId { get; set; }
        public string OficinaNome { get; set; }
        public List<AlunoModel>  Alunos { get; set; } = new List<AlunoModel>();
        public List<MonitorModel> Monitores { get; set; } = new List<MonitorModel>();
        public ProfessorModel Professor { get; set; }
        public int ProfessorId { get; set; }

        public void AlterarNomeOficina(string nome)
        {
            OficinaNome = nome;
        }

        public void AlterarProfessorOficina(ProfessorModel professor)
        {
            Professor = professor;
            ProfessorId = professor.Id;
        }

        public bool RemoverAlunoOficina(int AlunoId)
        {
            if (Alunos.FirstOrDefault(aluno => aluno.AlunoId == AlunoId) == null) { return false; }
            Alunos.RemoveAll(aluno => aluno.AlunoId == AlunoId);
            return true;
        }

        public bool RemoverMonitorOficina(int MonitorId)
        {
            if (Monitores.FirstOrDefault(monitor => monitor.Id == MonitorId) == null)
                return false;

            Monitores.RemoveAll(monitor => monitor.Id == MonitorId);
            return true;
        }
    }
}
