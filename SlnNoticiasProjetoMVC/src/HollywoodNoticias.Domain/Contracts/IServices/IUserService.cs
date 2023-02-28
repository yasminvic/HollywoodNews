using HollywoodNoticias.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Domain.Contracts.IServices
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<UserDTO> FindByLogin(string login);
    }
}
