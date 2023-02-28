using HollywoodNoticias.Domain.Entities;
using HollywoodNoticias.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace HollywoodNoticias.Infra.Data.Repository
{
    public class ContextoDatabase : DbContext
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> option)
            :base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Noticia>()
                .HasOne(n => n.Categoria)
                .WithMany(c => c.Noticias)
                .HasForeignKey(n => n.CategoriaId);

            modelBuilder.Entity<ConfiguracaoSistema>()
                .HasData(
                    new {Id = 1, NomeSite = "Hollywood News", Contato = "(47) 3333-3333", Endereco = "Rua Fulaninho de Tal, 2115"}
                );

            modelBuilder.Entity<Categoria>()
                .HasData(
                    new {Id = 1, Nome = "Filmes"},
                    new { Id = 2, Nome = "Séries" },
                    new { Id = 3, Nome = "Premiações" },
                    new { Id = 4, Nome = "Escândalos" }
                );

            modelBuilder.Entity<Noticia>()
                .HasData(
                    new { Id = 1, CategoriaId = 3, Titulo = "Vencedores Globo de Ouro 2023", Descricao = "\"The Fabelmans\", \"Os Banshees de Inisherin\", \"Abbott Elementary\" e \"House of the Dragon\" foram destaques da premiação, que ocorreu nesta terça-feira e elegeu os melhores filmes e programas de TV do ano passado", Texto = "A 80ª edição do Globo de Ouro ocorreu na noite desta terça-feira (10). A cerimônia abre a temporada de premiações de 2023 e é promovida pela Associação de Imprensa Estrangeira de Hollywood, que elege os melhores filmes e programas de TV do ano passado. ", EnderecoImagem = "https://www.rbsdirect.com.br/imagesrc/35808815.jpg?w=700&rv=2-10-05&safari" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new {Id = 1, Nome = "Yasmin", Email = "yasmin@gmail.com", Login = "yasminvic", Senha = "123", Perfil = PerfilEnum.Admin, DateCreated = DateTime.Now}
                );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<ConfiguracaoSistema> ConfiguracaoSistema { get; set; }
        public DbSet<NewsLetter> NewsLetter { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<User> User { get; set; }
        #endregion
    }
}
