using System;

<<<<<<< HEAD
namespace CarritoCompras.Models {
	public class Compra
=======
public class Compra
{
	public int Id { get; set; }
	public Cliente Cliente { get; set; }
	public Carrito Carrito { get; set; }
	public double Total { get; set; }

	public Compra()
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2
	{
		public int Id { get; set; }
		public Cliente Cliente { get; set; }
		public Carrito Carrito { get; set; }
		public double Total { get; set; }

		public Compra()
		{
		}
	}
}
