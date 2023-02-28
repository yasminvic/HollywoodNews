namespace HollywoodNoticias.Domain.DTO
{
    public class ComentarioDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int noticiaId { get; set; }
        public string text { get; set; }
        public DateTime dateCreated { get; set; }

        public virtual UserDTO? usuario { get; set; }
        public virtual NoticiaDTO? noticia { get; set; }
    }
}
