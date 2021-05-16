using System;
using System.ComponentModel.DataAnnotations;
using CarritoCompras.Data;

namespace CarritoCompras.Models
{

	public class Compra
	{
		public int Id { get; set; }
		public Cliente Cliente { get; set; }
		public Carrito Carrito { get; set; }
		//[DataType(DataType.Currency)]		????
		public double Total { get; set; }
		[Required]
		public int? ClienteId { get; set; }
		[Required]
		public int? CarritoId { get; set; }

	}
}