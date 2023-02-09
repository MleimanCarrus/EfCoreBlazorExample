﻿// <auto-generated />
using System;
using BlazorServerEFCoreDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServerEFCoreDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BlazorServerEFCoreDemo.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BlazorServerEFCoreDemo.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("BlazorServerEFCoreDemo.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(65,30)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("StudentID");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BlazorServerEFCoreDemo.Models.Student", b =>
                {
                    b.HasOne("BlazorServerEFCoreDemo.Models.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("BlazorServerEFCoreDemo.Models.Grade", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
