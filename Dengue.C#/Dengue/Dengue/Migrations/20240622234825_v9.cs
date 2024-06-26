using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dengue.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semana_Cidade",
                table: "Semanas");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Ano");

            migrationBuilder.DropIndex(
                name: "IX_Semanas_CidadeId",
                table: "Semanas");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Semanas");

            migrationBuilder.AddColumn<string>(
                name: "Ano",
                table: "Semanas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Semanas");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Semanas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<string>(type: "NVARCHAR(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Ano",
                        column: x => x.AnoId,
                        principalTable: "Ano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semanas_CidadeId",
                table: "Semanas",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ano_AnoReferencia",
                table: "Ano",
                column: "Ano");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_AnoId",
                table: "Cidades",
                column: "AnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semana_Cidade",
                table: "Semanas",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
