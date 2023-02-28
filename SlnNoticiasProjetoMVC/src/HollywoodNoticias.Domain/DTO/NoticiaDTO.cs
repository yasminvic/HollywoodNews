using HollywoodNoticias.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.DTO
{
    public class NoticiaDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Categoria")]
        public int categoriaId { get; set; }

        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Matéria")]
        public string texto { get; set; }

        [Display(Name = "Capa")]
        public string enderecoImagem { get; set; }

        public virtual CategoriaDTO? categoria { get; set; }
        public ICollection<ComentarioDTO>? comentarios { get; set; }

        public NoticiaDTO mapToDTO(Noticia noticia)
        {
            return new NoticiaDTO
            {
                id = noticia.Id,
                categoriaId = noticia.CategoriaId,
                titulo = noticia.Titulo,
                texto = noticia.Texto,
                descricao = noticia.Descricao,
                enderecoImagem = noticia.EnderecoImagem
            };
        }

        public Noticia mapToEntity()
        {
            return new Noticia
            {
                Id = id,
                CategoriaId = categoriaId,
                Titulo = titulo,
                Texto = texto,
                Descricao = descricao,
                EnderecoImagem = enderecoImagem
            };
        }
    }
}
