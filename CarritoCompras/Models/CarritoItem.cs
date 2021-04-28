using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{

	public class CarritoItem
	{
		public int Id { get; set; }
		public Carrito Carrito { get; set; }
		public Producto Producto { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public double ValorUnitario { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int Cantidad { get; set; }
		public double Subtotal { get; set; }
		public int CarritoId { get; set; }
		public int ProductoId { get; set; }
		public CarritoItem()
		{
		}
	}
}