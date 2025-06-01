using ELLP_Project.Interfaces.InterfacesEntidades;

namespace ELLP_Project.Models
{
    public class ProfessorModel : IProfessorEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<OficinaModel> Oficinas { get; set; }
        public string Salt { get; set; }
        public string SenhaHash { get; set; }
        public string Login { get; set; }

        public void AdicionarOficina(OficinaModel oficina)
        {
            Oficinas.Add(oficina);
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void RemoverOficina(int oficinaId)
        {
            Oficinas.RemoveAll(oficina => oficina.OficinaId == oficinaId);
        }
    }
}
