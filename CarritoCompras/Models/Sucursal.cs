using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
	public class Sucursal
	{
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int Id { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public string Nombre { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public string Direccion { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public string Telefono { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		[DataType(DataType.EmailAddress)]
		public List<StockItem> Stockitems;
		public string Email { get; set; }

		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int CompraId { get; set; }

		public Sucursal()
		{
		}
	}
}
