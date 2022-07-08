﻿// <auto-generated />
using System;
using Gourmet.Adaptors.SQLServerDataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gourmet.Adaptors.SQLServerDataAccess.Migrations
{
    [DbContext(typeof(PlantillaDB))]
    [Migration("20220707232654_Initialbase")]
    partial class Initialbase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Administrador", b =>
                {
                    b.Property<Guid>("Id_Admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Admin");

                    b.ToTable("tb_Administrador");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Bebida", b =>
                {
                    b.Property<Guid>("Id_Bebida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_CategoriaBebida")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id_Bebida");

                    b.HasIndex("Id_CategoriaBebida");

                    b.ToTable("tb_Bebida");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Categoria_Bebida", b =>
                {
                    b.Property<Guid>("Id_CategoriaBebida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoriaB")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_CategoriaBebida");

                    b.ToTable("tb_CategoriaBebida");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Categoria_Plato", b =>
                {
                    b.Property<Guid>("Id_CategoriaPlato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoriaP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_CategoriaPlato");

                    b.ToTable("tb_CategoriaPlato");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Detalle_Pedido", b =>
                {
                    b.Property<Guid>("Id_Detalle_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Pedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Monto_total")
                        .HasColumnType("int");

                    b.HasKey("Id_Detalle_Pedido");

                    b.HasIndex("Id_Pedido");

                    b.ToTable("tb_DetallePedido");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Menu", b =>
                {
                    b.Property<Guid>("Id_Menu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Plato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Bebida")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id_Menu", "Id_Plato", "Id_Bebida");

                    b.HasIndex("Id_Bebida");

                    b.HasIndex("Id_Plato");

                    b.ToTable("tb_Menu");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Pedido_Venta", b =>
                {
                    b.Property<Guid>("Id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad_Bebidas")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad_Platos")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Venta")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Bebida")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Plato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.HasKey("Id_Pedido");

                    b.HasIndex("Id_Bebida");

                    b.HasIndex("Id_Plato");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("tb_PedidoVenta");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Plato", b =>
                {
                    b.Property<Guid>("Id_Plato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_CategoriaPlato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id_Plato");

                    b.HasIndex("Id_CategoriaPlato");

                    b.ToTable("tb_Plato");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Usuario");

                    b.ToTable("tb_Usuario");
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Bebida", b =>
                {
                    b.HasOne("Gourmet.Core.Domain.Models.Categoria_Bebida", "Categoria_Bebida")
                        .WithMany("Bebidas")
                        .HasForeignKey("Id_CategoriaBebida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Detalle_Pedido", b =>
                {
                    b.HasOne("Gourmet.Core.Domain.Models.Pedido_Venta", "Pedido_Venta")
                        .WithMany("Detalle_Pedidos")
                        .HasForeignKey("Id_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Menu", b =>
                {
                    b.HasOne("Gourmet.Core.Domain.Models.Bebida", "Bebida")
                        .WithMany("Menus")
                        .HasForeignKey("Id_Bebida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gourmet.Core.Domain.Models.Plato", "Plato")
                        .WithMany("Menus")
                        .HasForeignKey("Id_Plato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Pedido_Venta", b =>
                {
                    b.HasOne("Gourmet.Core.Domain.Models.Bebida", "Bebida")
                        .WithMany("Pedido_Ventas")
                        .HasForeignKey("Id_Bebida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gourmet.Core.Domain.Models.Plato", "Plato")
                        .WithMany("Pedido_Ventas")
                        .HasForeignKey("Id_Plato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gourmet.Core.Domain.Models.Usuario", "Usuario")
                        .WithMany("Pedido_Ventas")
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gourmet.Core.Domain.Models.Plato", b =>
                {
                    b.HasOne("Gourmet.Core.Domain.Models.Categoria_Plato", "Categoria_Plato")
                        .WithMany("Platos")
                        .HasForeignKey("Id_CategoriaPlato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
