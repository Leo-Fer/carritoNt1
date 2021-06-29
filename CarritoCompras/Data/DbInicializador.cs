using CarritoCompras.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Data
{
    public class DbInicializador : IDbInicializador
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _rolManager;
        private readonly MiContexto _miContexto;


        public DbInicializador(UserManager<Usuario> usermgr, RoleManager<Rol> rolmgr, MiContexto micontexto)
        {
            _userManager = usermgr;
            _rolManager = rolmgr;
            _miContexto = micontexto;
        }

        public void Seed()
        {

            if (!_rolManager.Roles.Any())
            {
                IniciarRoles();
                CrearAdmin();
                CrearEmpleado();
                CrearRegistrosParaPruebas();
            }


        }

        private void IniciarRoles()
        {
            _rolManager.CreateAsync(new Rol() { Name = "Admin" }).Wait();
            _rolManager.CreateAsync(new Rol() { Name = "Empleado" }).Wait();
            _rolManager.CreateAsync(new Rol() { Name = "Cliente" }).Wait();

        }

        private async void CrearAdmin()
        {
            if (_userManager.FindByEmailAsync("Admin@admin.com").Result == null)
            {
                Usuario usuario = new Usuario();


                usuario.UserName = "Admin@admin.com";
                usuario.Email = usuario.UserName;
                usuario.Nombre = "Adminio";
                usuario.Apellido = "Iglesias";

                var resultadoDeUser = _userManager.CreateAsync(usuario, "Password1!").Result;

                if (resultadoDeUser.Succeeded)
                {
                    var exito = _userManager.AddToRoleAsync(usuario, "Admin").Result;
                    var exito2 = _userManager.AddToRoleAsync(usuario, "Empleado").Result;
                }
            }
        }

        private async void CrearEmpleado()
        {
            if (_userManager.FindByEmailAsync("Empleado@empleado.com").Result == null)
            {
                Usuario usuario = new Usuario();

                usuario.UserName = "empleado@empleado.com";
                usuario.Email = usuario.UserName;
                usuario.Nombre = "Carlos";
                usuario.Apellido = "Laburetti";
                usuario.Telefono = "4502-0974";
                usuario.Direccion = "Av. Del Trabajo 9001";

                var resultadoDeUser = _userManager.CreateAsync(usuario, "Password1!").Result;
                
                if (resultadoDeUser.Succeeded)
                {                    
                    var exito = _userManager.AddToRoleAsync(usuario, "Empleado").Result;
                }
            }


        }

            //LOS PRODUCTOS NO PUEDEN BORRARSE, POR LO TANTO SI NO EXISTE EL ID 1, NO HAY NADA CARGADO
            private async void CrearRegistrosParaPruebas()
        {
            if(_miContexto.Productos.FirstOrDefault(p => p.Id == 1) == null)
            {

                //      ALTA CATEGORIAS 

                Categoria sombreros = new Categoria() { Nombre = "Sombreros", Descripcion="Indumentaria para la cabeza" };
                Categoria zapatillas = new Categoria() { Nombre = "Zapatillas", Descripcion = "Calzado unisex"}; 
                Categoria pantalones = new Categoria() { Nombre = "Pantalones", Descripcion = "Prenda obligatoria por ley" };

                _miContexto.Categorias.Add(sombreros);
                _miContexto.Categorias.Add(pantalones);
                _miContexto.Categorias.Add(zapatillas);
                
                _miContexto.SaveChanges();

                //      ALTA PANTALONES

                Producto vaquero = new Producto() { Nombre = "Levi's 101", Activo = true, Descripcion = "Jeans tiro alto. Color azul. Botamanga automática.", PrecioVigente=5000 };
                vaquero.CategoriaId = pantalones.Id;

                Producto joggin = new Producto() { Nombre = "Adidas GymForce", Activo = false, Descripcion = "Gimnasia. Color gris. Lavar a mano.", PrecioVigente = 3000 };
                joggin.CategoriaId = pantalones.Id;

                Producto shortsNike = new Producto() { Nombre = "Nike Futbol", Activo = true, Descripcion = "Cortos para futbol. ClimaCool", PrecioVigente = 3000 };
                shortsNike.CategoriaId = pantalones.Id;

                _miContexto.Productos.Add(vaquero);
                _miContexto.Productos.Add(joggin);
                _miContexto.Productos.Add(shortsNike);
                _miContexto.SaveChanges();     
                
                //      ALTA SOMBREROS

                Producto bombin = new Producto() { Nombre = "Bombin", Activo = true, Descripcion = "Es un sombrerito", PrecioVigente = 750 };
                bombin.CategoriaId = sombreros.Id;

                Producto gorra = new Producto() { Nombre = "Gorra de beisbol", Activo = true, Descripcion = "Gorra beisbol NY yankees", PrecioVigente = 300 };
                gorra.CategoriaId = sombreros.Id;

                _miContexto.Productos.Add(bombin);
                _miContexto.Productos.Add(gorra);
                _miContexto.SaveChanges();

                //      ALTA ZAPATILLAS

                Producto nikesZapa = new Producto() { Nombre = "Nike 1301", Activo = true, Descripcion = "Mismas prestaciones que las 1300.", PrecioVigente = 7000 };
                nikesZapa.CategoriaId = zapatillas.Id;

                Producto crocs = new Producto() { Nombre = "CROCS", Activo = true, Descripcion = "Suela de goma. 43 agujeritos", PrecioVigente = 6500 };
                crocs.CategoriaId = zapatillas.Id;

                Producto converse = new Producto() { Nombre = "Converse CamAir", Activo = true, Descripcion = "Con cámara de aire", PrecioVigente = 9000 };
                converse.CategoriaId = zapatillas.Id;

                _miContexto.Productos.Add(nikesZapa);
                _miContexto.Productos.Add(crocs);
                _miContexto.Productos.Add(converse);
                _miContexto.SaveChanges();

                //      ALTA SUCURSALES

                Sucursal devoto = new Sucursal() { Direccion = "Av. Beiro 1534", Email = "devoto@sucursal.com", Nombre = "Devoto", Telefono = "4566-9713" };
                Sucursal abasto = new Sucursal() { Direccion = "Av. Corrientes 9301", Email = "abasto@sucursal.com", Nombre = "Abasto", Telefono = "4382-1533" };
                Sucursal urquiza = new Sucursal() { Direccion = "Roosevelt 2952", Email = "urquiza@sucursal.com", Nombre = "Villa Urquiza", Telefono = "4523-4832" };

                _miContexto.Sucursales.Add(devoto);
                _miContexto.Sucursales.Add(abasto);
                _miContexto.Sucursales.Add(urquiza);
                _miContexto.SaveChanges();

                //      ALTA STOCKITEMS

                StockItem vaqueroAbasto = new StockItem() { Cantidad = 30, ProductoId = vaquero.Id, SucursalId = abasto.Id };     
                StockItem jogginAbasto = new StockItem() { Cantidad = 50, ProductoId = joggin.Id, SucursalId = abasto.Id };
                StockItem gorraAbasto = new StockItem() { Cantidad = 100, ProductoId = gorra.Id, SucursalId = abasto.Id };
                StockItem nikesAbasto = new StockItem() { Cantidad = 90, ProductoId = nikesZapa.Id, SucursalId = abasto.Id };

                StockItem jogginUrquiza = new StockItem() { Cantidad = 30, ProductoId = joggin.Id, SucursalId = urquiza.Id };
                StockItem shortsUrquiza = new StockItem() { Cantidad = 40, ProductoId = shortsNike.Id, SucursalId = urquiza.Id };
                StockItem bombinUrquiza = new StockItem() { Cantidad = 200, ProductoId = bombin.Id, SucursalId = urquiza.Id };

                StockItem vaqueroDevoto = new StockItem() { Cantidad = 35, ProductoId = vaquero.Id, SucursalId = devoto.Id };
                StockItem crocsDevoto = new StockItem() { Cantidad = 30, ProductoId = crocs.Id, SucursalId = devoto.Id };
                StockItem converseDevoto = new StockItem() { Cantidad = 30, ProductoId = converse.Id, SucursalId = devoto.Id };

                _miContexto.StockItems.Add(vaqueroAbasto);
                _miContexto.StockItems.Add(jogginAbasto);
                _miContexto.StockItems.Add(gorraAbasto);
                _miContexto.StockItems.Add(nikesAbasto);
                _miContexto.StockItems.Add(jogginUrquiza);
                _miContexto.StockItems.Add(shortsUrquiza);
                _miContexto.StockItems.Add(bombinUrquiza);
                _miContexto.StockItems.Add(vaqueroDevoto);
                _miContexto.StockItems.Add(crocsDevoto);
                _miContexto.StockItems.Add(converseDevoto);
                _miContexto.SaveChanges();

            }

        }

    }
}
