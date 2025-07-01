using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios
{
    public class FaltaRepositorio : IFaltaRepositorio
    {
        private readonly List<FaltaModel> _faltas = new List<FaltaModel>();

        public FaltaModel AdicionarFalta(FaltaModel falta)
        {
            _faltas.Add(falta);
            return falta;
        }

        public FaltaModel AtualizarFalta(int faltaId, FaltaModel falta)
        {
            FaltaModel getFalta = _faltas.FirstOrDefault(falta => falta.FaltaId == faltaId);
            if(getFalta == null)
                return null;
            getFalta.AlterarAluno(falta.Aluno);
            getFalta.AlterarData(falta.DataFalta);
            getFalta.AlterarJustificativa(falta.JustificativaFalta);
            if (falta.FaltaJustificada == false)
            {
                getFalta.FaltaNaoJustificada();
            }else { getFalta.FaltaFoiJustificada(); }
            return getFalta;
        }

        public IEnumerable<FaltaModel> GetAllFaltas()
        {
            return _faltas;
        }

        public List<FaltaModel> GetFaltaByAluno(int alunoId)
        {
            return _faltas.Where(f => f.AlunoId==alunoId).ToList();
        }

        public FaltaModel? GetFaltaById(int id)
        {
            return _faltas.FirstOrDefault(f=> f.FaltaId==id);
        }

        public bool RemoverFalta(int id)
        {
            FaltaModel falta = _faltas.FirstOrDefault(f=> f.FaltaId==id);
            if(falta == null) return false;
            _faltas.Remove(falta);
            return true;
        }
    }
}
