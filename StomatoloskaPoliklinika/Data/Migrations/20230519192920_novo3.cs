using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StomatoloskaPoliklinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class novo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StomatologId",
                table: "UgovoreniSastanak",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stomatolog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", nullable: false),
                    BrojTelefona = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Lozinka = table.Column<string>(type: "TEXT", nullable: false),
                    Soecijalizacija = table.Column<string>(type: "TEXT", nullable: false),
                    Cijena = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stomatolog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UgovoreniSastanak_StomatologId",
                table: "UgovoreniSastanak",
                column: "StomatologId");

            migrationBuilder.AddForeignKey(
                name: "FK_UgovoreniSastanak_Stomatolog_StomatologId",
                table: "UgovoreniSastanak",
                column: "StomatologId",
                principalTable: "Stomatolog",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UgovoreniSastanak_Stomatolog_StomatologId",
                table: "UgovoreniSastanak");

            migrationBuilder.DropTable(
                name: "Stomatolog");

            migrationBuilder.DropIndex(
                name: "IX_UgovoreniSastanak_StomatologId",
                table: "UgovoreniSastanak");

            migrationBuilder.DropColumn(
                name: "StomatologId",
                table: "UgovoreniSastanak");
        }
    }
}
