using HollywoodNoticias.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.DTO
{

    public class CategoriaDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Categoria")]
        public string nome { get; set; }

        public virtual ICollection<NoticiaDTO>? noticias { get; set; }

        public Categoria mapToEntity()
        {
            return new Categoria
            {
                Id = id,
                Nome = nome,
            };

        }

        public CategoriaDTO mapToDTO(Categoria categoria)
        {
            return new CategoriaDTO
            {
                id = categoria.Id,
                nome = categoria.Nome,
            };

        }
    }

}
