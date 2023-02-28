namespace HollywoodNoticias.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NoticiaId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User? Usuario { get; set; }
        public virtual Noticia? Noticia { get; set; }
    }
}
