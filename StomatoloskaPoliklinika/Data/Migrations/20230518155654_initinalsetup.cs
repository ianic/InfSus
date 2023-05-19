using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StomatoloskaPoliklinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class initinalsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdPovijestBolesti",
                table: "Pacijent",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPovijestBolesti",
                table: "Pacijent",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
