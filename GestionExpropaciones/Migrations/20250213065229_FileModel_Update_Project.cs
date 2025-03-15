using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class FileModel_Update_Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastralMapModel");

            migrationBuilder.DropTable(
                name: "ExpropiatedPropModel");

            migrationBuilder.DropTable(
                name: "PropertyModel");

            migrationBuilder.DropTable(
                name: "OwnerModel");

            migrationBuilder.DropColumn(
                name: "Id_Expropiation_Type",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Finance_Data",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Legal_Data",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Id_Project_Data",
                table: "Files",
                newName: "Section");

            migrationBuilder.AddColumn<string>(
                name: "Km",
                table: "Files",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Project_Number",
                table: "Files",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Km",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Project_Number",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Files",
                newName: "Id_Project_Data");

            migrationBuilder.AddColumn<int>(
                name: "Id_Expropiation_Type",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Finance_Data",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Legal_Data",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CadastralMapModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastralMapModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadastralMapModel_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpropiatedPropModel",
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
                    table.PrimaryKey("PK_ExpropiatedPropModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpropiatedPropModel_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Last_Name1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Annotation = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    Id_Owner = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Property_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyModel_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyModel_OwnerModel_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadastralMapModel_FileId",
                table: "CadastralMapModel",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpropiatedPropModel_FileId",
                table: "ExpropiatedPropModel",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyModel_FileId",
                table: "PropertyModel",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyModel_OwnerId",
                table: "PropertyModel",
                column: "OwnerId");
        }
    }
}
