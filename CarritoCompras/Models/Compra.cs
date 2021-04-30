using System;
using System.ComponentModel.DataAnnotations;
using CarritoCompras.Data;

namespace CarritoCompras.Models {

public class Compra
{
	public int Id { get; set; }
	public Cliente Cliente { get; set; }
	public Carrito Carrito { get; set; }
	//[DataType(DataType.Currency)]		????
	public double Total { get; set; }

	public int ClienteId { get; set; }
	public int CarritoId { get; set; }
	public Compra(){}
	}
}
