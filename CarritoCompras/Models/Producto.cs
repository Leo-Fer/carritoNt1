﻿using System;

public class Producto
{
    public int Id { get; set }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double PrecioVigente { get; set; }
    public bool Activo { get; set; }

    public Producto()
	{
	}
}