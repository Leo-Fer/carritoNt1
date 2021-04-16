using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace CarritoCompras.Models {
	public class Sucursal
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

		public List<StockItem> Stockitems { get; set; } = new List<StockItem>();
=======
public class Sucursal
{
	public int Id { get; set; }
	public string Nombre { get; set; }
	public string Direccion { get; set; }
	public string Telefono { get; set; }
	public string Email { get; set; }

	public List<StockItem> Stockitems { get; set; }
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2

		public Sucursal()
		{
		}
	}
}
