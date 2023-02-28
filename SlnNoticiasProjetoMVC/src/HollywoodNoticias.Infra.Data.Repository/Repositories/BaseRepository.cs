using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ContextoDatabase _contexto;

        public BaseRepository(ContextoDatabase contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _contexto.Set<T>().FindAsync(id);
            _contexto.Set<T>().Remove(entity);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _contexto.Set<T>();
        }

        public async Task<int> Save(T entity)
        {
            await _contexto.Set<T>().AddAsync(entity);
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _contexto.Set<T>().Update(entity);
            return await _contexto.SaveChangesAsync();
        }
    }
}
