using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Projeto_gamer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Equipe",
                columns: table => new
                {
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipe", x => x.IdEquipe);
                });

            migrationBuilder.CreateTable(
                name: "_Jogador",
                columns: table => new
                {
                    IdJogador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEquipe = table.Column<int>(type: "int", nullable: false),
                    _EquipeIdEquipe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jogador", x => x.IdJogador);
                    table.ForeignKey(
                        name: "FK__Jogador__Equipe__EquipeIdEquipe",
                        column: x => x._EquipeIdEquipe,
                        principalTable: "_Equipe",
                        principalColumn: "IdEquipe");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Jogador__EquipeIdEquipe",
                table: "_Jogador",
                column: "_EquipeIdEquipe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Jogador");

            migrationBuilder.DropTable(
                name: "_Equipe");
        }
    }
}
