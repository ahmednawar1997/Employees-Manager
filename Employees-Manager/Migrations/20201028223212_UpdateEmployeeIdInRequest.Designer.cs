﻿// <auto-generated />
using System;
using Employees_Manager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employees_Manager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201028223212_UpdateEmployeeIdInRequest")]
    partial class UpdateEmployeeIdInRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Employees_Manager.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Request_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Request_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Employees_Manager.Models.Request", b =>
                {
                    b.Property<int>("Request_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("int");

                    b.Property<string>("Vacation_Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Request_Id");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Employees_Manager.Models.Vacation", b =>
                {
                    b.Property<int>("Vacation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Used")
                        .HasColumnType("int");

                    b.Property<string>("Vacation_Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Vacation_Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacation");
                });

            modelBuilder.Entity("Employees_Manager.Models.Employee", b =>
                {
                    b.HasOne("Employees_Manager.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("Request_Id");
                });

            modelBuilder.Entity("Employees_Manager.Models.Vacation", b =>
                {
                    b.HasOne("Employees_Manager.Models.Employee", null)
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}