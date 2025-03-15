using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Project_Table_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Files_FileId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_FileId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Id_File",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_File",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_FileId",
                table: "Project",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Files_FileId",
                table: "Project",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
