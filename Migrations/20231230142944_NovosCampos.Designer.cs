﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.Models;

#nullable disable

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231230142944_NovosCampos")]
    partial class NovosCampos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFinal.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteID"), 1L, 1);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Idade")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteID = 1,
                            CPF = "123.456.789-10",
                            Nome = "Uílha de Souza"
                        },
                        new
                        {
                            ClienteID = 2,
                            CPF = "123.456.789-11",
                            Nome = "Britinei Ispirs"
                        });
                });

            modelBuilder.Entity("ProjetoFinal.Models.Compra", b =>
                {
                    b.Property<int>("CompraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraID"), 1L, 1);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.HasKey("CompraID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Compras");

                    b.HasData(
                        new
                        {
                            CompraID = 1,
                            ClienteID = 2,
                            DataCompra = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1898),
                            FormaPagamento = "PIX",
                            ProdutoID = 2
                        });
                });

            modelBuilder.Entity("ProjetoFinal.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoID"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoUnit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoID");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoID = 1,
                            Nome = "PNY Geforce RTX 3060 12GB GDDR6",
                            PrecoUnit = 2099.90m
                        },
                        new
                        {
                            ProdutoID = 2,
                            Nome = "EVGA Gerforce RTX 4090 24GB GDDR6",
                            PrecoUnit = 12999.99m
                        });
                });

            modelBuilder.Entity("ProjetoFinal.Models.Compra", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
