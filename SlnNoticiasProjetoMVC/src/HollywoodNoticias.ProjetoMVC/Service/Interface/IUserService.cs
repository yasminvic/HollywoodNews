using HollywoodNoticias.ProjetoMVC.Models.Entities;

namespace HollywoodNoticias.ProjetoMVC.Service.Interface
{
    public interface IUserService
    {
        User Cadastrar(User user);
        User FindByLogin(string login);
    }
}
