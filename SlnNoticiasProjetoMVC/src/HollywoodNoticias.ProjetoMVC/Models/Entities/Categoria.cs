using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.ProjetoMVC.Models.Entities
{
    [Table("categoria")]
    public class Categoria
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        public virtual ICollection<Noticia>? Noticias { get; set; }
    }
}
