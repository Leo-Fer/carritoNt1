using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarritoCompras.Data;
using CarritoCompras.Models;
using Microsoft.AspNetCore.Identity;

namespace CarritoCompras.Controllers
{
    public class CarritoItemsController : Controller
    {
        private readonly MiContexto _context;
        private readonly UserManager<Usuario> _userManager;


        public CarritoItemsController(MiContexto context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CarritoItems
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.CarritoItems.Include(c => c.Carrito).Include(c => c.Producto);
            return View(await miContexto.ToListAsync());
        }

        public async Task<IActionResult> MostrarCarrito(string email)
        {
            Usuario usr1 = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            Carrito car1 = _context.Carritos.FirstOrDefault(c => c.ClienteId == usr1.Id && c.Activo == true);

            var miContexto = _context.CarritoItems.Where(c => c.CarritoId == car1.Id).Include(c => c.Producto);
            return View(await miContexto.ToListAsync());
        }

        // GET: CarritoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItems
                .Include(c => c.Carrito)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            return View(carritoItem);
        }

        // GET: CarritoItems/Create
        public async Task<IActionResult> Create(int? id)
        {
            CarritoItem carritoItem;
            if (id != null)
            {
                carritoItem = await _context.CarritoItems.FindAsync(id);
                return View("Create", carritoItem);
            }
            return View();
        }

        // POST: CarritoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,CarritoId,ProductoId")] CarritoItem carritoItem)
        {
            CarritoItem car1 = _context.CarritoItems.Find(carritoItem.Id);
            car1.Cantidad = carritoItem.Cantidad;            

            if (ModelState.IsValid)
            {
                 _context.CarritoItems.Update(car1);
                 _context.SaveChanges();
            }
            return RedirectToAction("Index", "Categorias");
        }

        // GET: CarritoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItems.FindAsync(id);
            if (carritoItem == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id", carritoItem.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", carritoItem.ProductoId);
            return View(carritoItem);
        }

        // POST: CarritoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,CarritoId,ProductoId")] CarritoItem carritoItem)
        {
            if (id != carritoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoItemExists(carritoItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                var car1 = _context.Carritos.FirstOrDefault(c => c.Id == carritoItem.CarritoId);
                var cli = _context.Usuarios.FirstOrDefault(c => c.Id == car1.ClienteId);            
                string email = cli.Email;
                return RedirectToAction("MostrarCarrito", new { email = email });
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id", carritoItem.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", carritoItem.ProductoId);
            return View(carritoItem);
        }

        // GET: CarritoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItems
                .Include(c => c.Carrito)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            return View(carritoItem);
        }

        // POST: CarritoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carritoItem = await _context.CarritoItems.FindAsync(id);
            _context.CarritoItems.Remove(carritoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoItemExists(int id)
        {
            return _context.CarritoItems.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Agregar(int id, string user)
        {
            Usuario usr1 = await _context.Usuarios.FirstOrDefaultAsync(p => p.Email == user);            

            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.ClienteId == usr1.Id && c.Activo == true);
            var prod = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            CarritoItem carritoItem = new CarritoItem();
            carritoItem.CarritoId = carrito.Id;
            carritoItem.ProductoId = prod.Id;
            _context.CarritoItems.Add(carritoItem);
            _context.SaveChanges();

        return RedirectToAction("Create", new { id = carritoItem.Id });
        }
    }
        
}
