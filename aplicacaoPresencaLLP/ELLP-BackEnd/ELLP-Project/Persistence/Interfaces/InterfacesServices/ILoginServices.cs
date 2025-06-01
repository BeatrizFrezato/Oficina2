using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesServices
{
    public interface ILoginServices
    {
        (bool sucesso, string perfil)? Autenticar(LoginModel login);
    }
}