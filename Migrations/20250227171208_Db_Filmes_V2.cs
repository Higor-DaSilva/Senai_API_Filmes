using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_filmes_senai.Migrations
{
    /// <inheritdoc />
    public partial class Db_Filmes_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_IdGenero",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.RenameTable(
                name: "Filme",
                newName: "Filmes");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_IdGenero",
                table: "Filmes",
                newName: "IX_Filmes_IdGenero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "IdFilme");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(50)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Genero_IdGenero",
                table: "Filmes",
                column: "IdGenero",
                principalTable: "Genero",
                principalColumn: "IdGenero",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Genero_IdGenero",
                table: "Filmes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Filme");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_IdGenero",
                table: "Filme",
                newName: "IX_Filme_IdGenero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "IdFilme");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_IdGenero",
                table: "Filme",
                column: "IdGenero",
                principalTable: "Genero",
                principalColumn: "IdGenero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
