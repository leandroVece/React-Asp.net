﻿// <auto-generated />
using System;
using Cadeteria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cadeteria.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230724193433_initail")]
    partial class initail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cadeteria.Models.CadeteCliente", b =>
                {
                    b.Property<Guid>("Id_cadClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CadeteForeingKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteForeingKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id_cadClient");

                    b.HasIndex("CadeteForeingKey");

                    b.HasIndex("ClienteForeingKey");

                    b.ToTable("cadeteCliente", (string)null);
                });

            modelBuilder.Entity("Cadeteria.Models.Cadetes", b =>
                {
                    b.Property<Guid>("Id_cadete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_cadete");

                    b.ToTable("cadete", (string)null);

                    b.HasData(
                        new
                        {
                            Id_cadete = new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc0"),
                            Direccion = "Entre rios",
                            Nombre = "Jaun Castellanos",
                            Telefono = "231321231"
                        },
                        new
                        {
                            Id_cadete = new Guid("0a9fa564-0604-4dfa-88df-3636fe395651"),
                            Direccion = "independencia",
                            Nombre = "Ana Hume",
                            Telefono = "231321231"
                        },
                        new
                        {
                            Id_cadete = new Guid("0a9fa564-0604-4dfa-88df-3636fe395678"),
                            Direccion = "independencia",
                            Nombre = "Fer Hume",
                            Telefono = "654321"
                        });
                });

            modelBuilder.Entity("Cadeteria.Models.Clientes", b =>
                {
                    b.Property<Guid>("Id_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id_cliente");

                    b.ToTable("cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id_cliente = new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc3"),
                            Direccion = "Entre rios",
                            Nombre = "Pancho Castellanos",
                            Telefono = "5231234"
                        },
                        new
                        {
                            Id_cliente = new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc1"),
                            Direccion = "independencia",
                            Nombre = "Lucio Hume",
                            Telefono = "8321156"
                        },
                        new
                        {
                            Id_cliente = new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc5"),
                            Direccion = "independencia",
                            Nombre = "Val Hume",
                            Telefono = "975313"
                        });
                });

            modelBuilder.Entity("Cadeteria.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id_pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteForeingKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Obs")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_pedido");

                    b.HasIndex("ClienteForeingKey");

                    b.ToTable("pedido", (string)null);

                    b.HasData(
                        new
                        {
                            Id_pedido = new Guid("adc4aba6-b2b6-4ca6-a715-e563987fd02e"),
                            ClienteForeingKey = new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc3"),
                            Estado = "Pendiente",
                            Obs = "Coca"
                        });
                });

            modelBuilder.Entity("Cadeteria.Models.CadeteCliente", b =>
                {
                    b.HasOne("Cadeteria.Models.Cadetes", "Cadete")
                        .WithMany("Cadp")
                        .HasForeignKey("CadeteForeingKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cadeteria.Models.Clientes", "Cliente")
                        .WithMany("Cadp")
                        .HasForeignKey("ClienteForeingKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cadete");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Cadeteria.Models.Pedido", b =>
                {
                    b.HasOne("Cadeteria.Models.Clientes", "Cliente")
                        .WithMany("listaPedido")
                        .HasForeignKey("ClienteForeingKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Cadeteria.Models.Cadetes", b =>
                {
                    b.Navigation("Cadp");
                });

            modelBuilder.Entity("Cadeteria.Models.Clientes", b =>
                {
                    b.Navigation("Cadp");

                    b.Navigation("listaPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
