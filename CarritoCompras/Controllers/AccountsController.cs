using CarritoCompras.Data;
using CarritoCompras.Models;
using CarritoCompras.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Controllers
{
    public class AccountsController : Controller
    {
        private readonly MiContexto _miContexto;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountsController(MiContexto micontexto, 
            UserManager<Usuario> userManager, 
            SignInManager<Usuario> signInManager)
        {
            this._miContexto = micontexto;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

       [HttpGet]
       public IActionResult RegistroUsuario()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarEmpleado()
        {
            return View("RegistroUsuario");
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEmpleado(string email)
        {
            
            if (ModelState.IsValid)
            {
                Usuario usr1 = new Usuario()
                {
                    Email = email,
                    UserName = email
                };
                var resultadoCreateUser = await _userManager.CreateAsync(usr1, "Password1!");

                if (resultadoCreateUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usr1, "Empleado");
                    return base.RedirectToAction("Create", "Usuarios", new { id = usr1.Id });
                }


            }
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> RegistroUsuario(Registrar modelo)
        {

            if (ModelState.IsValid)
            {
                Usuario usr1 = new Cliente()
                {
                    Email = modelo.Email,
                    UserName = modelo.Email
                };

                var resultadoCreateUser = await _userManager.CreateAsync(usr1, modelo.Password);

                if (resultadoCreateUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usr1, "Cliente");
                    await _signInManager.SignInAsync(usr1, true);
                    return base.RedirectToAction("Create", "Clientes", new { id = usr1.Id });
                }

                foreach(var error in resultadoCreateUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(modelo);
        }

        public async Task<IActionResult> EmailDisponible(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            if(usuario == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El correo {email} ya está siendo utilizado");
            }
        }
        [HttpGet]
        public IActionResult IniciarSesion(string returnurl)
        {
            TempData["returnUrl"] = returnurl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login modelo)
        {
            //tratamiento al modelo 

            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(modelo.NombreUsuario, modelo.Password, modelo.Recordarme, false);

                if (resultado.Succeeded)
                {
                    var returnl = TempData["returnUrl"] as string;
                    if (!string.IsNullOrEmpty(returnl))
                    {
                        return Redirect(returnl);
                    }
                   
                    return RedirectToAction("Index", "Productos");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión incorrecto.");

                return View(modelo);
            }
            return View();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
