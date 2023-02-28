using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.DTO
{
    public class ConfiguracaoSistemaDTO
    {
        public int id { get; set; }

        public string nomeSite { get; set; }

        public string contato { get; set; }

        public string endereco { get; set; }
    }
}
