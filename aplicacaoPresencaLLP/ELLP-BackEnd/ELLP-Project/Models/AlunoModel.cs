using ELLP_Project.Persistence.Interfaces.InterfacesEntidades;

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
            AlterarAlunoNome(nome);
        }

        public bool AlterarFalta(int faltaId, DateOnly? novaData = null, string? novaJustificativa = null, bool? justificada = null)
        {
            FaltaModel alunoFalta = AlunoFaltas.FirstOrDefault(f => f.FaltaId == faltaId);
            if (alunoFalta == null)
                return false;
            if (novaData != null)
                alunoFalta.AlterarData(novaData.Value);
            if (justificada != null)
                if (justificada==false) alunoFalta.FaltaNaoJustificada();
                else alunoFalta.FaltaFoiJustificada();
            if (novaJustificativa != null)
                alunoFalta.AlterarJustificativa(novaJustificativa);
            return true;
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

        public bool RemoverFalta(int faltaId)
        {
            if(AlunoFaltas.FirstOrDefault(falta => falta.FaltaId == faltaId) == null)
                return false;
            AlunoFaltas.RemoveAll(falta => falta.FaltaId == faltaId);
            return true;
        }


    }
}
