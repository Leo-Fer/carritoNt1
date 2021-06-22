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
    public class ComprasController : Controller
    {
        private readonly MiContexto _context;
        private readonly UserManager<Usuario> _userManager;

        public ComprasController(MiContexto context, UserManager<Usuario> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.Compras.Include(c => c.Carrito).Include(c => c.Cliente);
            return View(await miContexto.ToListAsync());
        }

        // GET PARA VERIFICAR STOCK
        [HttpGet]
        public async Task<IActionResult> VerificarStock(string userName, int sucursalId)
        {
            Usuario usr1 = await _userManager.FindByNameAsync(userName);
            Carrito car1 = _context.Carritos.FirstOrDefault(c => c.ClienteId == usr1.Id && c.Activo);
            
            List<CarritoItem> carritoItemsOfCustomer = _context.CarritoItems.Where(c => c.CarritoId == car1.Id).ToList();
            Sucursal sucursalSeleccionada = _context.Sucursales.FirstOrDefault(s => s.Id == sucursalId);
            List<StockItem> stockItemsEnSucursal = _context.StockItems.Where(s => s.SucursalId == sucursalSeleccionada.Id).ToList();

            bool sePuedeComprar = true;
            foreach(CarritoItem carrito in carritoItemsOfCustomer)
            {            

                int productoRecorrido = carrito.ProductoId;
                int cantidadProducto = carrito.Cantidad;
                if (stockItemsEnSucursal.FirstOrDefault(si => si.ProductoId == productoRecorrido) != null && sePuedeComprar)
                {
                    int cantidadEnStock = stockItemsEnSucursal.FirstOrDefault(si => si.ProductoId == productoRecorrido).Cantidad;

                    if (cantidadEnStock < cantidadProducto)
                    {
                        sePuedeComprar = false;
                        return RedirectToAction("CompraFail", "Compras", new { user = userName });
                    }
                }

                //PREVIENE QUE SE ROMPA CUANDO LA SUCURSAL NO TIENE STOCK DEL PRODUCTO (ARRIBA CHEQUEA LA CANTIDAD SI TIENE)

                if (stockItemsEnSucursal.FirstOrDefault(si => si.ProductoId == productoRecorrido) == null)
                {
                    sePuedeComprar = false;
                    return RedirectToAction("CompraFail", "Compras", new { user = userName });
                }
            }

            return await descontarStockEnSucursal(carritoItemsOfCustomer, stockItemsEnSucursal, usr1.Id, car1.Id);
        }

        public async Task<IActionResult> descontarStockEnSucursal(List<CarritoItem> carritoItemsComprados, List<StockItem> stockItemsEnSucursal, int usuarioId, int carritoId)
        {
            Double total = 0;
            //List<StockItem> stockItemsEnSucursal = _context.StockItems.Where(s => s.SucursalId == sucursalSeleccionada.Id).ToList();
            foreach (CarritoItem c in carritoItemsComprados)
            {
                int IdDelProductoComprado = c.ProductoId;
                int cantidadDelProducto = c.Cantidad;
                StockItem stockDelProducto = stockItemsEnSucursal.FirstOrDefault(s => s.ProductoId == IdDelProductoComprado);
                stockDelProducto.Cantidad = stockDelProducto.Cantidad - cantidadDelProducto;
                _context.StockItems.Update(stockDelProducto);
                await _context.SaveChangesAsync();

                //CALCULO EL TOTAL PARA CREAR LA COMPRA

                Producto prod = _context.Productos.FirstOrDefault(p => p.Id == c.ProductoId);
                
                total = total + c.Cantidad * prod.PrecioVigente;

                //ELIMINO LOS CARRITOITEM

                _context.CarritoItems.Remove(c);
                _context.SaveChanges();
            }
                        
            return await CompraSuccess(usuarioId, carritoId, total, stockItemsEnSucursal[0].SucursalId);
        }


        public async Task<IActionResult> CompraSuccess(int usuarioId, int carritoId, double total, int sucursalId)
        {
            Compra compraSuccess = new Compra();
            compraSuccess.ClienteId = usuarioId;
            compraSuccess.CarritoId = carritoId;
            compraSuccess.Total = total;
            _context.Compras.Add(compraSuccess);
            await _context.SaveChangesAsync();

            //DESACTIVO CARRITO

            Carrito carritoInactivo = _context.Carritos.FirstOrDefault(c => c.Id == carritoId);
            carritoInactivo.Activo = false;

            //CREO NUEVO CARRITO PARA EL CLIENTE

            Carrito carritoActivo = new Carrito();
            carritoActivo.Activo = true;
            carritoActivo.ClienteId = usuarioId;
            _context.Carritos.Add(carritoActivo);
            _context.SaveChanges();

            Sucursal suc = _context.Sucursales.FirstOrDefault(s => s.Id == sucursalId);
            ViewData["SucursalDireccion"] = suc.Direccion;
            ViewData["SucursalTelefono"] = suc.Telefono;
            ViewData["SucursalNombre"] = suc.Nombre;

            return View("CompraSuccess");
        }

        public async Task<IActionResult> CompraFail(string user)
        {
            Usuario usr1 = await _userManager.FindByNameAsync(user);
            Carrito car1 = _context.Carritos.FirstOrDefault(c => c.ClienteId == usr1.Id && c.Activo);
            List<CarritoItem> carritoItemsOfCustomer = _context.CarritoItems.Where(c => c.CarritoId == car1.Id).ToList();
            List<Sucursal> listaResultado = new List<Sucursal>();
            int itemsValidados = 0;

            bool finDeSucursales = false;
            int i = 1;
            while (!finDeSucursales)
            {
                Sucursal suc = _context.Sucursales.FirstOrDefault(s => s.Id == i);

                if(suc != null)
                {
                    List<StockItem> stockItemsEnSucursal = _context.StockItems.Where(s => s.SucursalId == suc.Id).ToList();

                    foreach (CarritoItem carrito in carritoItemsOfCustomer)
                    {
                        int productoId = carrito.ProductoId;
                        int productoCantidad = carrito.Cantidad;
                                                

                        if ((stockItemsEnSucursal.FirstOrDefault(si => si.ProductoId == productoId) != null) 
                            && (stockItemsEnSucursal.FirstOrDefault(si => si.ProductoId == productoId).Cantidad) >= productoCantidad)
                        {
                            itemsValidados++;
                        }
                    }

                    if (itemsValidados == carritoItemsOfCustomer.Count)
                    {
                        listaResultado.Add(suc);
                    }

                    itemsValidados = 0;
                } 
                else
                {
                    finDeSucursales = true;
                }

                i++;
            }

            return View(listaResultado);
        }



        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Carrito)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,ClienteId,CarritoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id", compra.CarritoId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", compra.ClienteId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id", compra.CarritoId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", compra.ClienteId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,ClienteId,CarritoId")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "Id", "Id", compra.CarritoId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", compra.ClienteId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Carrito)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}
