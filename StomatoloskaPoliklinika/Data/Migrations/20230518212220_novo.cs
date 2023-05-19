using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StomatoloskaPoliklinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UgovoreniSastanak_Pacijent_IdPacijent",
                table: "UgovoreniSastanak");

            migrationBuilder.DropIndex(
                name: "IX_UgovoreniSastanak_IdPacijent",
                table: "UgovoreniSastanak");

            migrationBuilder.AddColumn<int>(
                name: "PacijentId",
                table: "UgovoreniSastanak",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UgovoreniSastanak_PacijentId",
                table: "UgovoreniSastanak",
                column: "PacijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UgovoreniSastanak_Pacijent_PacijentId",
                table: "UgovoreniSastanak",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UgovoreniSastanak_Pacijent_PacijentId",
                table: "UgovoreniSastanak");

            migrationBuilder.DropIndex(
                name: "IX_UgovoreniSastanak_PacijentId",
                table: "UgovoreniSastanak");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "UgovoreniSastanak");

            migrationBuilder.CreateIndex(
                name: "IX_UgovoreniSastanak_IdPacijent",
                table: "UgovoreniSastanak",
                column: "IdPacijent");

            migrationBuilder.AddForeignKey(
                name: "FK_UgovoreniSastanak_Pacijent_IdPacijent",
                table: "UgovoreniSastanak",
                column: "IdPacijent",
                principalTable: "Pacijent",
                principalColumn: "Id");
        }
    }
}
