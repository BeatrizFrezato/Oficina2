namespace ELLP_Project.Models
{
    public class OficinaModel
    {
        public int OficinaId { get; set; }
        public string OficinaNome { get; set; }
        public List<AlunoModel> Alunos { get; set; } = new List<AlunoModel>();
        public List<MonitorModel> Monitores { get; set; } = new List<MonitorModel>();
        public ProfessorModel Professor { get; set; }
    }
}
