using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavanderia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Agregaciondelcampocedulaoidentificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Clientes");
        }
    }
}
