using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarritoCompras.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarritoCompras.Data
{
    public class MiContexto : IdentityDbContext
    {
        public MiContexto(DbContextOptions options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockItem>().HasKey(si => new { si.SucursalId, si.ProductoId });

            modelBuilder.Entity<StockItem>().HasOne(si => si.Sucursal).WithMany(s => s.Stockitems).HasForeignKey(si => si.SucursalId);
            modelBuilder.Entity<StockItem>().HasOne(si => si.Producto).WithMany(p => p.Stockitems).HasForeignKey(si => si.ProductoId);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Usuarios");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsuariosRoles");


        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Sucursal> Sucursales{ get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Rol> Roles { get; set; }



    }




}
