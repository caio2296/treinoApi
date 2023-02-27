﻿// <auto-generated />
using System;
using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FluentApi.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20230227143710_AppIncial")]
    partial class AppIncial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FluentApi.Models.BuracoNegro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GalaxiaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("GalaxiaId");

                    b.ToTable("BuracosNegros");
                });

            modelBuilder.Entity("FluentApi.Models.Galaxia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Tamanho")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Galaxias");
                });

            modelBuilder.Entity("FluentApi.Models.Planeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GalaxiaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Tamanho")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GalaxiaId")
                        .IsUnique();

                    b.ToTable("Planetas");
                });

            modelBuilder.Entity("FluentApi.Models.BuracoNegro", b =>
                {
                    b.HasOne("FluentApi.Models.Galaxia", "Galaxia")
                        .WithMany("buracoNegros")
                        .HasForeignKey("GalaxiaId");
                });

            modelBuilder.Entity("FluentApi.Models.Planeta", b =>
                {
                    b.HasOne("FluentApi.Models.Galaxia", "Galaxia")
                        .WithOne("Planeta")
                        .HasForeignKey("FluentApi.Models.Planeta", "GalaxiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
