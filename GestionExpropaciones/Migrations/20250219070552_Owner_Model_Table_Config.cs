using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Owner_Model_Table_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last_Name2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email12 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Identification_Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Owner_Type = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_FileId",
                table: "Owners",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
