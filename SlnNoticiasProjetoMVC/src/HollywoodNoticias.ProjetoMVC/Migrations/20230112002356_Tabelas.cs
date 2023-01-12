using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HollywoodNoticias.ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "configsist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomesite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configsist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "newsletter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsletter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    perfil = table.Column<int>(type: "int", nullable: false),
                    dataCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "noticia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enderecoImagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noticia", x => x.id);
                    table.ForeignKey(
                        name: "FK_noticia_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Filmes" },
                    { 2, "Séries" },
                    { 3, "Premiações" },
                    { 4, "Escândalos" }
                });

            migrationBuilder.InsertData(
                table: "configsist",
                columns: new[] { "id", "contato", "endereco", "nomesite" },
                values: new object[] { 1, "(47) 3333-3333", "Rua Fulaninho de Tal, 2115", "Hollywood News" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "dataCreated", "email", "login", "nome", "perfil", "senha" },
                values: new object[] { 1, new DateTime(2023, 1, 11, 21, 23, 56, 146, DateTimeKind.Local).AddTicks(6422), "yasmin@gmail.com", "yasminvic", "Yasmin", 1, "123" });

            migrationBuilder.InsertData(
                table: "noticia",
                columns: new[] { "id", "CategoriaId", "descricao", "enderecoImagem", "texto", "titulo" },
                values: new object[] { 1, 3, "\"The Fabelmans\", \"Os Banshees de Inisherin\", \"Abbott Elementary\" e \"House of the Dragon\" foram destaques da premiação, que ocorreu nesta terça-feira e elegeu os melhores filmes e programas de TV do ano passado", "https://www.rbsdirect.com.br/imagesrc/35808815.jpg?w=700&rv=2-10-05&safari", "A 80ª edição do Globo de Ouro ocorreu na noite desta terça-feira (10). A cerimônia abre a temporada de premiações de 2023 e é promovida pela Associação de Imprensa Estrangeira de Hollywood, que elege os melhores filmes e programas de TV do ano passado. ", "Vencedores Globo de Ouro 2023" });

            migrationBuilder.CreateIndex(
                name: "IX_noticia_CategoriaId",
                table: "noticia",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configsist");

            migrationBuilder.DropTable(
                name: "newsletter");

            migrationBuilder.DropTable(
                name: "noticia");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
