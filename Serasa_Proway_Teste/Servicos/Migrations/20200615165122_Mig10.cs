using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Servicos.Migrations
{
    public partial class Mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(55)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debitos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Nome", "Rating" },
                values: new object[,]
                {
                    { 1, "Serasa", 50m },
                    { 2, "ProWay", 50m },
                    { 3, "LivrariaNerd", 50m },
                    { 4, "UniMasters", 50m },
                    { 5, "Code.Org", 50m },
                    { 6, "Udemy", 50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debitos_EmpresaId",
                table: "Debitos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_EmpresaId",
                table: "NotasFiscais",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debitos");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
