using ELLP_Project.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class AlunoModel:IAlunoEntidade
    {
        public int AlunoId { get; set; }
        public string AlunoNome { get; set; }
        public List<FaltaModel> AlunoFaltas { get; set; }
        public List<OficinaModel> AlunoOficinas { get; set; }

        public void AdicionarFalta(FaltaModel falta)
        {
            AlunoFaltas.Add(falta);
        }

        public void AlterarAlunoNome(string nome)
        {
            AlunoNome = nome;
        }

        public void AlterarFalta(int faltaId, DateOnly? novaData = null, string? novaJustificativa = null, bool? justificada = null)
        {
            FaltaModel alunoFalta = AlunoFaltas.FirstOrDefault(f => f.FaltaId == faltaId);
            if (alunoFalta == null)
                throw new Exception("Não existe essa falta no aluno.");
            if (novaData != null)
                alunoFalta.DataFalta = novaData.Value;
            if (justificada != null)
                alunoFalta.FaltaJustificada = justificada.Value;
            if (novaJustificativa != null)
                alunoFalta.JustificativaFalta = novaJustificativa;
        }

        public List<FaltaModel> FaltasAluno()
        {
            return AlunoFaltas;
        }

        public int NumeroFaltas()
        {
            return AlunoFaltas.Count;
        }

        public List<OficinaModel> OficinasAluno()
        {
            return AlunoOficinas;
        }

        public void removerFalta(int faltaId)
        {
            AlunoFaltas.RemoveAll(falta => falta.FaltaId == faltaId);
        }
    }
}
