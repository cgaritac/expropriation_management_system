using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    /// <inheritdoc />
    public partial class Changes_in_file_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cadastral_map",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Files",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Files",
                newName: "Start_Date");

            migrationBuilder.RenameColumn(
                name: "finish_date",
                table: "Files",
                newName: "Finish_Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Files",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Files",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Finish_Date",
                table: "Files",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Files",
                type: "nvarchar(max)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "Id_Project_Data",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Active",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Files",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CadastralMapModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cadastral_Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
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
                name: "ExpropietedPropertyModel",
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
                    table.PrimaryKey("PK_ExpropietedPropertyModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpropietedPropertyModel_Files_FileId",
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
                    Last_Name1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identification_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Type = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false)
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
                    Property_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Canton = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annotation = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false),
                    Id_File = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Id_Owner = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ExpropietedPropertyModel_FileId",
                table: "ExpropietedPropertyModel",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastralMapModel");

            migrationBuilder.DropTable(
                name: "ExpropietedPropertyModel");

            migrationBuilder.DropTable(
                name: "PropertyModel");

            migrationBuilder.DropTable(
                name: "OwnerModel");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Fase",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Expropiation_Type",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Finance_Data",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Legal_Data",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Id_Project_Data",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Files",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Start_Date",
                table: "Files",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "Finish_Date",
                table: "Files",
                newName: "finish_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "finish_date",
                table: "Files",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cadastral_map",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
