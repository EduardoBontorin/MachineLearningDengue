using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dengue.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Climas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precipitacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Umidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClimasSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    TemperaturaMaxima = table.Column<double>(type: "float", nullable: false),
                    TemperaturaMinima = table.Column<double>(type: "float", nullable: false),
                    TotalPrecipitacao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimasSemana", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Semanas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    Notificacoes = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sequencial = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semana_Cidade",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ano_AnoReferencia",
                table: "Ano",
                column: "Ano");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_AnoId",
                table: "Cidades",
                column: "AnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Semana_Sequencial",
                table: "Semanas",
                column: "Sequencial");

            migrationBuilder.CreateIndex(
                name: "IX_Semanas_CidadeId",
                table: "Semanas",
                column: "CidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Climas");

            migrationBuilder.DropTable(
                name: "ClimasSemana");

            migrationBuilder.DropTable(
                name: "Semanas");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Ano");
        }
    }
}
