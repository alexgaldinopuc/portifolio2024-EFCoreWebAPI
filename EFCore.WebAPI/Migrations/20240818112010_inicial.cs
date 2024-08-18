using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeroiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armas_Herois_HeroiID",
                        column: x => x.HeroiID,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Batalhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: true),
                    HeroiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IdentidadesSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeReal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeroiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadesSecretas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadesSecretas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeroisBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Armas_HeroiID",
                table: "Armas",
                column: "HeroiID");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_BatalhaId",
                table: "Batalhas",
                column: "BatalhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_HeroiId",
                table: "Batalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "HeroisBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadesSecretas");

            migrationBuilder.DropTable(
                name: "Batalhas");

            migrationBuilder.DropTable(
                name: "Herois");
        }
    }
}
