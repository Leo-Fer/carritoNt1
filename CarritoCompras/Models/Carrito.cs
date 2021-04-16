using System;
using System.Collections.Generic;

public class Carrito
{
	public int Id { get; set; }
	public bool Activo { get; set; }
	public Cliente Cliente { get; set; }
	public List<CarritoItem> CarritoItems;
	public double Subtotal { get; set; }


	public Carrito()
	{
	}
}
