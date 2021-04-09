using System;



public class Cliente : Usuario
{
    public int Id { get; set }
    public string Dni { get; set; }
    public List<Carrito> Carritos { get; set; }
    public List<Compra> Compras { get; set; }



    public Cliente()
	{
	}
}
