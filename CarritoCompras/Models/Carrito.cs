using System;

public class Carrito
{

	public bool Activo { get; set; }
	public Cliente Cliente { get; set; }
	public List<CarritoItem> CarritosItem;
	public double Subtotal { get; set; }


	public Carrito()
	{
	}
}
