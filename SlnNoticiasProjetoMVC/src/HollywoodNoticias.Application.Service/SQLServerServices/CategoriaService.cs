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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaDTO>> GetAll()
        {
            List<CategoriaDTO> listdto = new List<CategoriaDTO>();
            foreach (var item in _repository.GetAll()) 
            {
                var catdto = new CategoriaDTO();
                listdto.Add(catdto.mapToDTO(item));
            }

            return listdto;
        }

        public async Task<CategoriaDTO> GetById(int id)
        {
            var entity = new CategoriaDTO();
            return entity.mapToDTO(await _repository.FindById(id));
        }

        public async Task<int> Save(CategoriaDTO entity)
        {
            if(entity.id > 0)
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

    }
}
