﻿// <auto-generated />
using System;
using AssistenciaTecnicaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssistenciaTecnicaApi.Migrations
{
    [DbContext(typeof(AssistenciaContext))]
    [Migration("20240222172715_mudançabanco2222222222222222")]
    partial class mudançabanco2222222222222222
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.AparelhoModel", b =>
                {
                    b.Property<int>("IdAparelho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdAparelho");

                    b.ToTable("Aparelhos");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ClienteEndereco", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.HasKey("IdCliente", "IdEndereco");

                    b.HasIndex("IdEndereco");

                    b.ToTable("ClientesEnderecos");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdOrdem")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.EnderecoModel", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("NumeroDaResidencia")
                        .HasColumnType("int");

                    b.HasKey("IdEndereco");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.OrdemModel", b =>
                {
                    b.Property<int>("IdOrdem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdAparelho")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdResponsavel")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdOrdem");

                    b.HasIndex("IdAparelho");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdResponsavel");

                    b.ToTable("Ordens");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ResponsavelModel", b =>
                {
                    b.Property<int>("IdResponsavel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdResponsavel");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ClienteEndereco", b =>
                {
                    b.HasOne("AssistenciaTecnicaApi.Models.ClienteModel", "Cliente")
                        .WithMany("ClienteEndereco")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistenciaTecnicaApi.Models.EnderecoModel", "Endereco")
                        .WithMany("ClienteEndereco")
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.OrdemModel", b =>
                {
                    b.HasOne("AssistenciaTecnicaApi.Models.AparelhoModel", "Aparelho")
                        .WithMany("Ordens")
                        .HasForeignKey("IdAparelho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistenciaTecnicaApi.Models.ClienteModel", "Cliente")
                        .WithMany("Ordens")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistenciaTecnicaApi.Models.ResponsavelModel", "Responsavel")
                        .WithMany("Ordens")
                        .HasForeignKey("IdResponsavel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aparelho");

                    b.Navigation("Cliente");

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.AparelhoModel", b =>
                {
                    b.Navigation("Ordens");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ClienteModel", b =>
                {
                    b.Navigation("ClienteEndereco");

                    b.Navigation("Ordens");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.EnderecoModel", b =>
                {
                    b.Navigation("ClienteEndereco");
                });

            modelBuilder.Entity("AssistenciaTecnicaApi.Models.ResponsavelModel", b =>
                {
                    b.Navigation("Ordens");
                });
#pragma warning restore 612, 618
        }
    }
}
