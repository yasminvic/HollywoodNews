using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.ProjetoMVC.Models.Entities
{
    [Table("noticia")]
    public class Noticia
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        
        [Column("titulo")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("texto")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Column("enderecoImagem")]
        [Display(Name = "Capa")]
        public string EnderecoImagem { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
