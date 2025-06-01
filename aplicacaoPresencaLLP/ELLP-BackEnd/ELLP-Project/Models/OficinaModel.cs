using ELLP_Project.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class OficinaModel : IOficinaEntidade
    {
        public int OficinaId { get; set; }
        public string OficinaNome { get; set; }
        public List<AlunoModel> Alunos { get; set; } = new List<AlunoModel>();
        public List<MonitorModel> Monitores { get; set; } = new List<MonitorModel>();
        public ProfessorModel Professor { get; set; }

        public void AlterarNomeOficina(string nome)
        {
            OficinaNome = nome;
        }

        public void AlterarProfessorOficina(ProfessorModel professor)
        {
            Professor = professor;
        }

        public void RemoverAlunoOficina(int AlunoId)
        {
            Alunos.RemoveAll(aluno => aluno.AlunoId == AlunoId);

        }

        public void RemoverMonitorOficina(int MonitorId)
        {
            Monitores.RemoveAll(monitor => monitor.Id == MonitorId);
        }
    }
}
