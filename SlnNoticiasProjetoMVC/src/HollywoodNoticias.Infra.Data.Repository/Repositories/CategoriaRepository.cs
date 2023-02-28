using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Infra.Data.Repository.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ContextoDatabase _contexto;
        public CategoriaRepository(ContextoDatabase contexto) 
            : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
