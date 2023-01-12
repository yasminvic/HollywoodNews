using HollywoodNoticias.ProjetoMVC.Models;
using HollywoodNoticias.ProjetoMVC.Models.Entities;

namespace HollywoodNoticias.ProjetoMVC.Repository
{
    public class UserRepository
    {
        private readonly ContextoDatabase _context;

        public UserRepository(ContextoDatabase contexto)
        {
            _context = contexto;
        }

        public User CadastrarUser(User user)
        {
            user.DateCreated = DateTime.Now;
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        internal User FindUserByLogin(string login)
        {
            User usuario = _context.User.FirstOrDefault(u => u.Login == login);
            return usuario;
        }
    }
}
