﻿using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class StockItem
{
	public int Id { get; set }
	public Sucursal Sucursal { get; set }
	public Producto Producto { get; set }
	public int Cantidad { get; set }

	public StockItem()
	{
	}
}
