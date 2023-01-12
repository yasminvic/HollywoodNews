using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.ProjetoMVC.Models.Entities
{
    [Table("noticia")]
    public class Noticia
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("texto")]
        public string Texto { get; set; }

        [Column("enderecoImagem")]
        public string EnderecoImagem { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
