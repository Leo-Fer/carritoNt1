using System;

namespace CarritoCompras.Models
{
<<<<<<< HEAD
	public class CarritoItem
=======
	public int Id { get; set; }
	public Carrito Carrito { get; set; }
	public Producto Producto { get; set; }
	public double ValorUnitario { get; set; }
	public int Cantidad { get; set; }
	public double Subtotal { get; set; }

	public CarritoItem()
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2
	{
		public int Id { get; set; }
		public Carrito Carrito { get; set; }
		public Producto Producto { get; set; }
		public double ValorUnitario { get; set; }
		public int Cantidad { get; set; }
		public double Subtotal { get; set; }

		public CarritoItem()
		{
		}
	}
}