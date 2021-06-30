using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarritoCompras.Data;
using CarritoCompras.Models;

namespace CarritoCompras.Controllers
{
    public class CarritosController : Controller
    {
        private readonly MiContexto _context;

        public CarritosController(MiContexto context)
        {
            _context = context;
        }

        // GET: Carritos
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.Carritos.Include(c => c.Cliente);
            return View(await miContexto.ToListAsync());
        }

        // GET: Carritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }



        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }
    }
}
