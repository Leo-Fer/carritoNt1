using System;


namespace CarritoCompras.Models {

public class Compra
{
	public int Id { get; set; }
	public Cliente Cliente { get; set; }
	public Carrito Carrito { get; set; }
	public double Total { get; set; }
	public Compra(){}
	}
}
