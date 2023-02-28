using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.Entities
{
    [Table("newsletter")]
    public class NewsLetter
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
