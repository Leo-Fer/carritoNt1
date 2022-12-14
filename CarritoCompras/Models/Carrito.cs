using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarritoCompras.Models
{
	public class Carrito
	{
		public int Id { get; set; }

		public bool Activo { get; set; }

		public List<CarritoItem> CarritoItems { get; set; }
		[NotMapped]
		[Range(0.00, double.MaxValue, ErrorMessage = ErrorMsgs.ErrorMenorACero)]
		public double Subtotal { get; set; }
		public Cliente Cliente { get; set; }
		[Required]
		public int ClienteId { get; set; }

    }
}