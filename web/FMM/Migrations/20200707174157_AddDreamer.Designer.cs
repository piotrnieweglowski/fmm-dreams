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
    [Migration("20200707174157_AddDreamer")]
    partial class AddDreamer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FMM.Persistent.Dream", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Dreams");
                });

            modelBuilder.Entity("FMM.Persistent.Dreamer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DreamId")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("GuardianContact")
                        .HasColumnType("text");

                    b.Property<string>("PhotoAsBase64")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DreamId");

                    b.ToTable("Dreamers");
                });

            modelBuilder.Entity("FMM.Persistent.Dreamer", b =>
                {
                    b.HasOne("FMM.Persistent.Dream", "Dream")
                        .WithMany()
                        .HasForeignKey("DreamId");
                });
#pragma warning restore 612, 618
        }
    }
}
