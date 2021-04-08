using System;

public class Carrito
{

	public bool Activo { get; set; }
	public Cliente Cliente { get; set; }
	public list<CarritoItem> CarritosItem;
	public double Subtotal { get; set; }


	public Carrito()
	{
		CarritosItem = new list<CarritoItem>();
	}
}
