using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Sucursal
{
	public int Id { get; set }
	public string Nombre { get; set }
	public string Direccion { get; set }
	public string Telefono { get; set }
	public string Email { get; set }

	public List<StockItem> Stockitems { get; set }

	public Sucursal()
	{
	}
}
