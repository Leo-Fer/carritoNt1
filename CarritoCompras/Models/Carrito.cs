using System;
using System.Collections.Generic;

namespace CarritoCompras.Models
{
<<<<<<< HEAD
	public class Carrito
	{
		public int Id { get; set; }
		public bool Activo { get; set; }
		public Cliente Cliente { get; set; }
		public List<CarritoItem> CarritoItems = new List<CarritoItem>();
		public double Subtotal { get; set; }
=======
	public int Id { get; set; }
	public bool Activo { get; set; }
	public Cliente Cliente { get; set; }
	public List<CarritoItem> CarritoItems;
	public double Subtotal { get; set; }
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2


		public Carrito()
		{
		}
	}
}
