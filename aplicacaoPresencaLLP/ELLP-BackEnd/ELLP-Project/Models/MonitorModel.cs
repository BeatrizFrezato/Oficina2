namespace ELLP_Project.Models
{
    public class MonitorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public OficinaModel Oficina { get; set; }
        public string Salt { get; set; }
        public string SenhaHash { get; set; }
        public string Login { get; set; }
    }
}
