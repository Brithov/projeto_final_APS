﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using democsharp.Models;

#nullable disable

namespace Prova2_APS.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231214173456_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Prova2_APS.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Prova2_APS.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Percentual")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Prova2_APS.Models.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Prova2_APS.Models.NotaVenda", b =>
                {
                    b.Property<int>("NotaVendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Tipo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("NotaVendaId");

                    b.ToTable("NotasVenda");
                });

            modelBuilder.Entity("Prova2_APS.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLimite")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Pago")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("PagamentoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Prova2_APS.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Prova2_APS.Models.TipoPagamento", b =>
                {
                    b.Property<int>("TipoPagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InformacoesAdicionais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeDoCobrado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TipoPagamentoId");

                    b.ToTable("TiposPagamento");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TipoPagamento");
                });

            modelBuilder.Entity("Prova2_APS.Models.Transporte", b =>
                {
                    b.Property<int>("TransporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TransporteId");

                    b.ToTable("Transportes");
                });

            modelBuilder.Entity("Prova2_APS.Models.Vendedor", b =>
                {
                    b.Property<int>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VendedorId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("Prova2_APS.Models.PagamentoCartao", b =>
                {
                    b.HasBaseType("Prova2_APS.Models.TipoPagamento");

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PagamentoCartao_Bandeira");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PagamentoCartao_NumeroCartao");

                    b.Property<int>("PagamentoCartaoId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PagamentoCartao");
                });

            modelBuilder.Entity("Prova2_APS.Models.PagamentoCheque", b =>
                {
                    b.HasBaseType("Prova2_APS.Models.TipoPagamento");

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PagamentoChequeId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PagamentoCheque");
                });

            modelBuilder.Entity("Prova2_APS.Models.Produto", b =>
                {
                    b.HasOne("Prova2_APS.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });
#pragma warning restore 612, 618
        }
    }
}
