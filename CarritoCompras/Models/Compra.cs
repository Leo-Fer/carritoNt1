using System;
using System.ComponentModel.DataAnnotations;
using CarritoCompras.Data;

namespace CarritoCompras.Models {

public class Compra
{
	public int Id { get; set; }
	public Cliente Cliente { get; set; }
	public Carrito Carrito { get; set; }

	[Required(ErrorMessage= ErrorMsgs.ErrorRequerido)]
	public double Total { get; set; }

	public int ClienteId { get; set; }
	public int CarritoId { get; set; }
	public Compra(){}
	}
}
