using System;

public class Carrito
{

	public bool Activo { get; set; }
	public Cliente Cliente { get; set; }
	public CarritoItem CarritoItem { get; set; }
	public double Subtotal { get; set; }


	public Carrito()
	{
	}
}
