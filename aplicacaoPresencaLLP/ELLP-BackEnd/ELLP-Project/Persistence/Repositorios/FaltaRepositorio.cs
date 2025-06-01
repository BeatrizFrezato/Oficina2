using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios
{
    public class FaltaRepositorio : IFaltaRepositorio
    {
        private readonly List<FaltaModel> _faltas = new List<FaltaModel>();

        public void AdicionarFalta(FaltaModel falta)
        {
            _faltas.Add(falta);
        }

        public bool AtualizarFalta(int faltaId, FaltaModel falta)
        {
            FaltaModel getFalta = _faltas.FirstOrDefault(falta => falta.FaltaId == faltaId);
            if(getFalta == null)
                return false;
            getFalta.AlterarAluno(falta.Aluno);
            getFalta.AlterarData(falta.DataFalta);
            getFalta.AlterarJustificativa(falta.JustificativaFalta);
            if (falta.FaltaJustificada == false)
            {
                getFalta.FaltaNaoJustificada();
            }else { getFalta.FaltaFoiJustificada(); }
            return true;
        }

        public IEnumerable<FaltaModel> GetAllFaltas()
        {
            throw new NotImplementedException();
        }

        public FaltaModel? GetFaltaById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoverFalta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
