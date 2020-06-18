﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servicos.ViewModel;

namespace Servicos.Migrations
{
    [DbContext(typeof(EmpresaRatingDbContext))]
    [Migration("20200615165122_Mig10")]
    partial class Mig10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Modelos.Debito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Debitos");
                });

            modelBuilder.Entity("Dominio.Modelos.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(55)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Serasa",
                            Rating = 50m
                        },
                        new
                        {
                            Id = 2,
                            Nome = "ProWay",
                            Rating = 50m
                        },
                        new
                        {
                            Id = 3,
                            Nome = "LivrariaNerd",
                            Rating = 50m
                        },
                        new
                        {
                            Id = 4,
                            Nome = "UniMasters",
                            Rating = 50m
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Code.Org",
                            Rating = 50m
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Udemy",
                            Rating = 50m
                        });
                });

            modelBuilder.Entity("Dominio.Modelos.NotaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("NotasFiscais");
                });

            modelBuilder.Entity("Dominio.Modelos.Debito", b =>
                {
                    b.HasOne("Dominio.Modelos.Empresa", "Empresa")
                        .WithMany("Debitos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Modelos.NotaFiscal", b =>
                {
                    b.HasOne("Dominio.Modelos.Empresa", "Empresa")
                        .WithMany("NotasFicais")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
