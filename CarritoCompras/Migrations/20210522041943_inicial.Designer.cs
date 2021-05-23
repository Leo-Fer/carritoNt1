﻿// <auto-generated />
using System;
using CarritoCompras.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarritoCompras.Migrations
{
    [DbContext(typeof(MiContexto))]
    [Migration("20210522041943_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarritoCompras.Models.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("CarritoCompras.Models.CarritoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CarritoItems");
                });

            modelBuilder.Entity("CarritoCompras.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(140)")
                        .HasMaxLength(140);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CarritoCompras.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarritoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("CarritoCompras.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(140)")
                        .HasMaxLength(140);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("PrecioVigente")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CarritoCompras.Models.StockItem", b =>
                {
                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("SucursalId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("CarritoCompras.Models.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("CarritoCompras.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("CarritoCompras.Models.Cliente", b =>
                {
                    b.HasBaseType("CarritoCompras.Models.Usuario");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("CarritoCompras.Models.Carrito", b =>
                {
                    b.HasOne("CarritoCompras.Models.Cliente", "Cliente")
                        .WithOne("carrito")
                        .HasForeignKey("CarritoCompras.Models.Carrito", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoCompras.Models.CarritoItem", b =>
                {
                    b.HasOne("CarritoCompras.Models.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarritoCompras.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoCompras.Models.Compra", b =>
                {
                    b.HasOne("CarritoCompras.Models.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarritoCompras.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoCompras.Models.Producto", b =>
                {
                    b.HasOne("CarritoCompras.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarritoCompras.Models.StockItem", b =>
                {
                    b.HasOne("CarritoCompras.Models.Producto", "Producto")
                        .WithMany("Stockitems")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarritoCompras.Models.Sucursal", "Sucursal")
                        .WithMany("Stockitems")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}