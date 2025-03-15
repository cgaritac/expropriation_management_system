using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Other_Models_Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appraisals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appraisal_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Appraisal_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Estimated_Appraisal = table.Column<double>(type: "float", nullable: false),
                    Real_Appraisal = table.Column<double>(type: "float", nullable: false),
                    Payment_Status = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appraisals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appraisals_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpropiatedProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cadastral_Map = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpropiatedProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpropiatedProperties_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastralMap_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Folio_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Annotation = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerProperties_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaperWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Document_Date = table.Column<DateTime>(type: "date", nullable: false),
                    PaperWork_type = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_On = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperWorks_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appraisals_FileId",
                table: "Appraisals",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpropiatedProperties_FileId",
                table: "ExpropiatedProperties",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerProperties_FileId",
                table: "OwnerProperties",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperWorks_FileId",
                table: "PaperWorks",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appraisals");

            migrationBuilder.DropTable(
                name: "ExpropiatedProperties");

            migrationBuilder.DropTable(
                name: "OwnerProperties");

            migrationBuilder.DropTable(
                name: "PaperWorks");
        }
    }
}
