﻿// <auto-generated />
using System;
using FMM.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FMM.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200710162125_AddVolunteers")]
    partial class AddVolunteers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FMM.Persistent.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FMM.Persistent.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FMM.Persistent.Dream", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Dreams");
                });

            modelBuilder.Entity("FMM.Persistent.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("FMM.Persistent.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("StepId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("FMM.Persistent.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("FMM.Persistent.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("FMM.Persistent.Dream", b =>
                {
                    b.HasOne("FMM.Persistent.Volunteer", null)
                        .WithMany("Dreams")
                        .HasForeignKey("VolunteerId");
                });

            modelBuilder.Entity("FMM.Persistent.Task", b =>
                {
                    b.HasOne("FMM.Persistent.Step", null)
                        .WithMany("Tasks")
                        .HasForeignKey("StepId");
                });

            modelBuilder.Entity("FMM.Persistent.Volunteer", b =>
                {
                    b.HasOne("FMM.Persistent.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("FMM.Persistent.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}