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
            }

           
        }

        private void IniciarRoles()
        {
            _rolManager.CreateAsync(new Rol() { Name = "Admin" }).Wait();
            _rolManager.CreateAsync(new Rol() { Name = "Usuario" }).Wait();
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

                var resultadoDeUser = _userManager.CreateAsync(usuario, "Adminpass1!").Result;

                if (resultadoDeUser.Succeeded)
                {
                    var exito = _userManager.AddToRoleAsync(usuario, "Admin").Result;
                }
            }
        }
    }
}
