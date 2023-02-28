using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Domain.Contracts.IRepositories
{
    public interface IBaseRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
