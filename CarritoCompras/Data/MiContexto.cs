using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarritoCompras.Models;

namespace CarritoCompras.Data
{
    public class MiContexto : DbContext
    {
        public MiContexto(DbContextOptions options) :base(options)
        {
            
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



    }




}
