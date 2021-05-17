using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
public class StockItem
	{
		//public int Id { get; set; }
		// configurar muchos amuchos
		
		public Sucursal Sucursal { get; set; }
		public Producto Producto { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		[Range(0, int.MaxValue, ErrorMessage = ErrorMsgs.ErrorValorNegativo)]
		public int Cantidad { get; set; }
	
		public int SucursalId { get; set; }
		public int ProductoId { get; set; }

	}
}