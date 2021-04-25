using System;


namespace CarritoCompras.Models {
public class StockItem
	{
		public int Id { get; set; }
		public Sucursal Sucursal { get; set; }
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }
		public int SucursalId { get; set; }
		public int ProductoId { get; set; }
		public StockItem(){}
	}
}