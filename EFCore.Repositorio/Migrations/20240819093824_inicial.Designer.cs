﻿// <auto-generated />
using System;
using EFCore.Repositorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Repositorio.Migrations
{
    [DbContext(typeof(HeroiContext))]
    [Migration("20240819093824_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EFCore.Dominio.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroiID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HeroiID");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Batalha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatalhaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int?>("HeroiId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BatalhaId");

                    b.HasIndex("HeroiId");

                    b.ToTable("Batalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.HeroiBatalha", b =>
                {
                    b.Property<int>("BatalhaId")
                        .HasColumnType("int");

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.HasKey("BatalhaId", "HeroiId");

                    b.HasIndex("HeroiId");

                    b.ToTable("HeroisBatalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.IdentidadeSecreta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroiId")
                        .HasColumnType("int");

                    b.Property<string>("NomeReal")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HeroiId")
                        .IsUnique();

                    b.ToTable("IdentidadesSecretas");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Arma", b =>
                {
                    b.HasOne("EFCore.Dominio.Models.Heroi", "Heroi")
                        .WithMany("Armas")
                        .HasForeignKey("HeroiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Batalha", b =>
                {
                    b.HasOne("EFCore.Dominio.Models.Batalha", null)
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("BatalhaId");

                    b.HasOne("EFCore.Dominio.Models.Heroi", null)
                        .WithMany("HeroisBatalhas")
                        .HasForeignKey("HeroiId");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.HeroiBatalha", b =>
                {
                    b.HasOne("EFCore.Dominio.Models.Batalha", "Batalha")
                        .WithMany()
                        .HasForeignKey("BatalhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Dominio.Models.Heroi", "Heroi")
                        .WithMany()
                        .HasForeignKey("HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batalha");

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.IdentidadeSecreta", b =>
                {
                    b.HasOne("EFCore.Dominio.Models.Heroi", "Heroi")
                        .WithOne("IdentidadeSecreta")
                        .HasForeignKey("EFCore.Dominio.Models.IdentidadeSecreta", "HeroiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heroi");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Batalha", b =>
                {
                    b.Navigation("HeroisBatalhas");
                });

            modelBuilder.Entity("EFCore.Dominio.Models.Heroi", b =>
                {
                    b.Navigation("Armas");

                    b.Navigation("HeroisBatalhas");

                    b.Navigation("IdentidadeSecreta");
                });
#pragma warning restore 612, 618
        }
    }
}
