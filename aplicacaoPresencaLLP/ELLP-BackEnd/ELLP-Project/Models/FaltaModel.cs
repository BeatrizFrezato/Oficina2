using ELLP_Project.Persistence.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class FaltaModel : IFaltaEntidade
    {
        public AlunoModel Aluno { get; set; }
        public int AlunoId { get; set; }
        public int FaltaId { get; set; }
        public DateOnly DataFalta { get; set; }
        public string? JustificativaFalta { get; set; }
        public Boolean FaltaJustificada { get; set; }

        public void AlterarAluno(AlunoModel aluno)
        {
            Aluno = aluno;
            AlunoId = aluno.AlunoId;
        }

        public void AlterarData(DateOnly data)
        {
            DataFalta = data;
        }

        public void AlterarJustificativa(string justificativa)
        {
            JustificativaFalta = justificativa;
        }

        public void FaltaNaoJustificada()
        {
            FaltaJustificada = false;
        }

        public void FaltaFoiJustificada()
        {
            FaltaJustificada = true;
        }
    }
}
