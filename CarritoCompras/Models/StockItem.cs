using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
public class StockItem
	{
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int Id { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public Sucursal Sucursal { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }
	
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int SucursalId { get; set; }
		[Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
		public int ProductoId { get; set; }

		public StockItem(){
		}
	}
}