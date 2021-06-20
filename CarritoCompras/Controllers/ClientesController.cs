using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarritoCompras.Data;
using Microsoft.AspNetCore.Identity;
using CarritoCompras.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarritoCompras.Controllers
{
    public class ClientesController : Controller
    {
        private readonly MiContexto _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _rolmanager;

        public ClientesController(
            MiContexto context, 
            UserManager<Usuario> usermanager, 
            RoleManager<Rol> rolmanager)
        {
            _context = context;
            _userManager = usermanager;
            _rolmanager = rolmanager;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create(int? id)
        {
            Cliente cliente;
            if (id != null)
            {
                cliente = await _context.Clientes.FindAsync(id);
                return View("Create", cliente);
            }
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dni,Id,Nombre,Apellido,Direccion,Telefono,Email,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //Por si el Administrador quiere agregar cliente
                if (cliente.Email == null)
                {
                    ModelState.AddModelError("Email", $"El {nameof(cliente.Email)} es requerido.");
                    return View(cliente);
                }
                
                IdentityResult resu = await CreoCliente(cliente);


                return RedirectToAction("index", "Home");
            }
            return View(cliente);
        }

        private async Task<IdentityResult> CreoCliente(Cliente cliente)
        {
            IdentityResult resultado = new IdentityResult();

            if (cliente.Id == 0)//creación interna
            {
                cliente.UserName = cliente.Email;
                resultado = await _userManager.CreateAsync(cliente, cliente.PasswordHash);
            }
            else if (cliente.Id != 0) //creación con registración previa
            {

                Cliente clt = _context.Clientes.Find(cliente.Id);
                if (clt != null)
                {
                    clt.Nombre = cliente.Nombre;
                    clt.Apellido = cliente.Apellido;
                    clt.Email = cliente.Email;
                    clt.Dni = cliente.Dni;
                    clt.Direccion = cliente.Direccion;
                    clt.FechaAlta = DateTime.Now;
                    clt.Telefono = cliente.Telefono;
                    resultado = await _userManager.UpdateAsync(clt);

                    Carrito carrito = new Carrito();
                    carrito.Activo = true;
                    carrito.ClienteId = cliente.Id;

                    var exito = _context.Carritos.Add(carrito);
                    _context.SaveChanges();
                }

            }

            return resultado;
        }


        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dni,Id,Nombre,Apellido,Direccion,Telefono,Email,FechaAlta,Password,UserRol")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }

    
}
