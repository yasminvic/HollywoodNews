using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodNoticias.Infra.Data.Repository.Repositories
{
    public class NoticiaRepository : BaseRepository<Noticia>, INoticiaRepository
    {
        private readonly ContextoDatabase _contexto;
        public NoticiaRepository(ContextoDatabase contexto) 
            : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
