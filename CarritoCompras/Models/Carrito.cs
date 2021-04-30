using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{
	public class Carrito
	{
		public int Id { get; set; }
		//[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]	CONSULTAR MARIANO
		public bool Activo { get; set; }
		public Cliente Cliente { get; set; }

		public List<CarritoItem> CarritoItems;
		public double Subtotal { get; set; }
		public int ClienteId { get; set; }
		public int CarritoItemId { get; set; }
		public Carrito()
		{
		}
	}
}
