using CarritoCompras.Data;
using CarritoCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Controllers
{
    public class HomeController : Controller
    {
        private readonly MiContexto _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MiContexto context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
            MostrarCategorias();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> MostrarCategorias()
        {
            List<Categoria> listaDeCategorias = _context.Categorias.ToList();
            ViewBag.listaDeCategorias = new List<String> { "Hola", "Gola"};
           //ViewData["listaDeCategorias"] = listaDeCategorias;
            return View();
        }

    }
}
