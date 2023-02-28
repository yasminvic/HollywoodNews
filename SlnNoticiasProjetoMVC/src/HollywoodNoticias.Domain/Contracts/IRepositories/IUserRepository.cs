using HollywoodNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Domain.Contracts.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindUserByLogin(string login);
    }
}
