using HollywoodNoticias.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("perfil")]
        public PerfilEnum Perfil { get; set; }

        [Column("dataCreated")]
        public DateTime DateCreated { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }

        public bool ValidaSenha(string senha)
        {
            return Senha.Equals(senha);
        }
    }
}
