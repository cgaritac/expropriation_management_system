﻿// <auto-generated />
using System;
using GestionExpropaciones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionExpropaciones.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250218075323_Section_Elimination_From_Project_Model")]
    partial class Section_Elimination_From_Project_Model
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionExpropaciones.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2100)")
                        .HasColumnName("Comments");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Created_By");

                    b.Property<int>("Fase")
                        .HasColumnType("int")
                        .HasColumnName("Fase");

                    b.Property<DateTime?>("Finish_Date")
                        .HasColumnType("date")
                        .HasColumnName("Finish_Date");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Active");

                    b.Property<string>("Km")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Km");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Number");

                    b.Property<string>("Project_Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Project_Number");

                    b.Property<int>("Section")
                        .HasColumnType("int")
                        .HasColumnName("Section");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("date")
                        .HasColumnName("Start_Date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Files", (string)null);
                });

            modelBuilder.Entity("GestionExpropaciones.Models.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2100)")
                        .HasColumnName("Comments");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Created_By");

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("date")
                        .HasColumnName("Created_On");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.ToTable("Project", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
