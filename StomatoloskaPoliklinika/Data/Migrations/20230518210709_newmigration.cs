using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StomatoloskaPoliklinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPovijestBolesti",
                table: "Pacijent",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "UgovoreniSastanak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumVrijeme = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    IdPacijent = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UgovoreniSastanak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UgovoreniSastanak_Pacijent_IdPacijent",
                        column: x => x.IdPacijent,
                        principalTable: "Pacijent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UgovoreniSastanak_IdPacijent",
                table: "UgovoreniSastanak",
                column: "IdPacijent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UgovoreniSastanak");

            migrationBuilder.AlterColumn<string>(
                name: "IdPovijestBolesti",
                table: "Pacijent",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
