﻿// <auto-generated />
using Desafio_Ilia_PARR.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Desafio_Ilia_PARR.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Desafio_Ilia_PARR.Model.Alocacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<string>("dia")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("dia");

                    b.Property<string>("nomeProjeto")
                        .HasColumnType("longtext")
                        .HasColumnName("nomeProjeto");

                    b.Property<string>("tempo")
                        .HasColumnType("longtext")
                        .HasColumnName("tempo");

                    b.HasKey("Id");

                    b.ToTable("alocacao");
                });

            modelBuilder.Entity("Desafio_Ilia_PARR.Model.Momento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<string>("dataHora")
                        .HasColumnType("longtext")
                        .HasColumnName("dataHora");

                    b.HasKey("Id");

                    b.ToTable("momento");
                });
#pragma warning restore 612, 618
        }
    }
}
