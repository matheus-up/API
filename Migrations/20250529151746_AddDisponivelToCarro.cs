using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDisponivelToCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Carros",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Carros");
        }
    }
}
