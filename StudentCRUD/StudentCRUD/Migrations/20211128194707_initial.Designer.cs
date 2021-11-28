﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentCRUD.Helper;

namespace StudentCRUD.Migrations
{
    [DbContext(typeof(StudentDBContext))]
    [Migration("20211128194707_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("StudentCRUD.Models.ClassEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("class_name");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.HasKey("Id");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("StudentCRUD.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("StudentCRUD.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("class_id");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(16)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CountryId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("StudentCRUD.Models.Student", b =>
                {
                    b.HasOne("StudentCRUD.Models.ClassEntities", "ClassEntities")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentCRUD.Models.Country", "Countries")
                        .WithMany("Students")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassEntities");

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("StudentCRUD.Models.ClassEntities", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentCRUD.Models.Country", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}