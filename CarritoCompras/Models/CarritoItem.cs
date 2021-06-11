using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarritoCompras.Models
{

	public class CarritoItem
	{
		public int Id { get; set; }
		public Carrito Carrito { get; set; }
		public Producto Producto { get; set; }
		[NotMapped]
		[Range(0, double.MaxValue, ErrorMessage = ErrorMsgs.ErrorDeRange)]
		public double ValorUnitario { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		[Range(0, double.MaxValue, ErrorMessage = ErrorMsgs.ErrorDeRange)]
		// maxValue reemplazar con cantidad del stock para el item
		public int Cantidad { get; set; }
		[NotMapped]
		[Range(0.01, double.MaxValue, ErrorMessage = ErrorMsgs.ErrorMenorACero)]
		public double Subtotal { get; set; }

		
		public int CarritoId { get; set; }
	
		
		public int ProductoId { get; set; }
		
	}
}