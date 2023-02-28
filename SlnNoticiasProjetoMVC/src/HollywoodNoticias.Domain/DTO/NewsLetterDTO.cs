using System.ComponentModel.DataAnnotations.Schema;

namespace HollywoodNoticias.Domain.DTO
{
    public class NewsLetter
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string email { get; set; }
    }
}
