using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.ProjetoMVC.Models.Entities
{
    [Table("configsist")]
    public class ConfiguracaoSistema
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nomesite")]
        public string NomeSite { get; set; }

        [Column("contato")]
        public string Contato { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }
    }
}
