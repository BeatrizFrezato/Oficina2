using ELLP_Project.Persistence.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class AlunoModel:IAlunoEntidade
    {
        public int AlunoId { get; set; }
        public string AlunoNome { get; set; }
        public List<FaltaModel> AlunoFaltas { get; set; } = new();
        public OficinaModel AlunoOficinas { get; set; } = new();
        public int OficinaId { get; set; }

        public void AdicionarFalta(FaltaModel falta)
        {
            AlunoFaltas.Add(falta);
        }

        public void AlterarAlunoNome(string nome)
        {
            AlunoNome=nome;
        }

        public List<FaltaModel> FaltasAluno()
        {
            return AlunoFaltas;
        }

        public int NumeroFaltas()
        {
            return AlunoFaltas.Count;
        }

        public OficinaModel OficinaAluno(OficinaModel oficina)
        {
            AlunoOficinas = oficina;
            OficinaId = oficina.OficinaId;
            return oficina;
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
