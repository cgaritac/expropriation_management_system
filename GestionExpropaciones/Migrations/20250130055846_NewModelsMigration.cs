using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class NewModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpropietedPropertyModel");

            migrationBuilder.CreateTable(
                name: "ExpropiatedPropModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastral_Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annotation = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpropiatedPropModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpropiatedPropModel_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpropiatedPropModel_FileId",
                table: "ExpropiatedPropModel",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpropiatedPropModel");

            migrationBuilder.CreateTable(
                name: "ExpropietedPropertyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Annotation = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Cadastral_Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Property_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpropietedPropertyModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpropietedPropertyModel_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpropietedPropertyModel_FileId",
                table: "ExpropietedPropertyModel",
                column: "FileId");
        }
    }
}
