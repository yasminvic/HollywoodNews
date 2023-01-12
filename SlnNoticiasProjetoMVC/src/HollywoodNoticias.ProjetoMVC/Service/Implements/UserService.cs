using HollywoodNoticias.ProjetoMVC.Models.Entities;
using HollywoodNoticias.ProjetoMVC.Repository;
using HollywoodNoticias.ProjetoMVC.Service.Interface;

namespace HollywoodNoticias.ProjetoMVC.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public User Cadastrar(User user)
        {
            return _repository.CadastrarUser(user);
        }

        public User FindByLogin(string login)
        {
            return _repository.FindUserByLogin(login);
        }
    }
}
