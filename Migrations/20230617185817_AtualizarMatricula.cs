using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Matricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Matricula",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
