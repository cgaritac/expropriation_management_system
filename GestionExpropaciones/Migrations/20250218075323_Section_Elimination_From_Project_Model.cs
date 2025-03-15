using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Section_Elimination_From_Project_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Final_Km",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Initial_Km",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Final_Km",
                table: "Project",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Initial_Km",
                table: "Project",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
