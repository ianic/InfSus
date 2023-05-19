using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StomatoloskaPoliklinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class novo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPacijent",
                table: "UgovoreniSastanak");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPacijent",
                table: "UgovoreniSastanak",
                type: "INTEGER",
                nullable: true);
        }
    }
}
