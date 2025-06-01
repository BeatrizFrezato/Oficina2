using ELLP_Project.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class AlunoModel:IAlunoEntidade
    {
        public int AlunoId { get; set; }
        public string AlunoNome { get; set; }
        public List<FaltaModel> AlunoFaltas { get; set; }
        public List<OficinaModel> AlunoOficinas { get; set; }

        public void AlterarAlunoNome(string nome)
        {
            AlunoNome = nome;
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
    }
}
