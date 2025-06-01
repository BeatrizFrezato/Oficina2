namespace ELLP_Project.Models
{
    public class FaltaModel
    {
        public AlunoModel Aluno { get; set; }
        public int FaltaId { get; set; }
        public DateOnly DatasFaltas { get; set; }
        public string JustificativaFalta { get; set; }
        public Boolean FaltaJustificada { get; set; }
    }
}
