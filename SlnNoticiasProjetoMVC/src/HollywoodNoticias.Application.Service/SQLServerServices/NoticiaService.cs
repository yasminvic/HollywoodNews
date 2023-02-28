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
    public class NoticiaService : INoticiaService
    {
        private readonly INoticiaRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;

        public NoticiaService(INoticiaRepository repository, ICategoriaRepository categoriaRepository)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<NoticiaDTO>> GetAll()
        {
            List<NoticiaDTO> listdto = new List<NoticiaDTO>();
            foreach (var item in _repository.GetAll())
            {
                var notdto = new NoticiaDTO();
                var catdto = new CategoriaDTO();

                var noticia = notdto.mapToDTO(item);
                noticia.categoria = catdto.mapToDTO(await _categoriaRepository.FindById(noticia.categoriaId));
                listdto.Add(noticia);
            }

            return listdto;
        }

        public async Task<NoticiaDTO> GetById(int id)
        {
            var entity = new NoticiaDTO();
            var cat = new CategoriaDTO();
            var entitydto = entity.mapToDTO(await _repository.FindById(id));
            entitydto.categoria = cat.mapToDTO(await _categoriaRepository.FindById(entitydto.categoriaId));
            return entitydto;
        }

        public async Task<int> Save(NoticiaDTO entity)
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
    }
}
