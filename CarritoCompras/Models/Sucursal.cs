using System;
using System.Collections.Generic;

namespace CarritoCompras.Models {
	public class Sucursal
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

		public List<StockItem> Stockitems { get; set; } = new List<StockItem>();

		public Sucursal()
		{
		}
	}
}
