using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Domain.Contracts.IServices;
using HollywoodNoticias.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Application.Service.SQLServerServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<UserDTO> listdto = new List<UserDTO>();
            foreach (var item in _repository.GetAll())
            {
                var userdto = new UserDTO();
                listdto.Add(userdto.mapToDTO(item));
            }

            return listdto;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var entity = new UserDTO();
            return entity.mapToDTO(await _repository.FindById(id));
        }

        public async Task<int> Save(UserDTO entity)
        {
            if (entity.id > 0)
            {
                return await _repository.Update(entity.mapToEntity());
            }
            else
            {
                return await _repository.Save(entity.mapToEntity());
            }
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<UserDTO> FindByLogin(string login)
        {
            var userdto = new UserDTO();
            return userdto.mapToDTO(await _repository.FindUserByLogin(login));
        }
    }
}
