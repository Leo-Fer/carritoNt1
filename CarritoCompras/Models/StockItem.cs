using System;

<<<<<<< HEAD
namespace CarritoCompras.Models {
	public class StockItem
=======

public class StockItem
{
	public int Id { get; set; }
	public Sucursal Sucursal { get; set; }
	public Producto Producto { get; set; }
	public int Cantidad { get; set; }

	public StockItem()
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2
	{
		public int Id { get; set; }
		public Sucursal Sucursal { get; set; }
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }

		public StockItem()
		{
		}
	}
}