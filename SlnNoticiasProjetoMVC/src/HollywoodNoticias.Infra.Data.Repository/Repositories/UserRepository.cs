using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Infra.Data.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ContextoDatabase _contexto;
        public UserRepository(ContextoDatabase contexto) 
            : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<User> FindUserByLogin(string login)
        {
            User usuario = _contexto.User.FirstOrDefault(u => u.Login == login);
            return usuario;
        }
    }
}
