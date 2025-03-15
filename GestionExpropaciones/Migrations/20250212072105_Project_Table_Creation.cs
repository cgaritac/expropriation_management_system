using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Project_Table_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Files",
                type: "nvarchar(2100)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Initial_Km = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Final_Km = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2100)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_FileId",
                table: "Project",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Files",
                type: "nvarchar(max)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2100)",
                oldMaxLength: 2000,
                oldNullable: true);
        }
    }
}
