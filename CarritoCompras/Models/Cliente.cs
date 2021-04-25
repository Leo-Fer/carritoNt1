using System;
using System.Collections.Generic;

namespace CarritoCompras.Models
{
    public class Cliente : Usuario
    {
        public string Dni { get; set; }
        public List<Carrito> Carritos { get; set; } = new List<Carrito>();
        public List<Compra> Compras { get; set; } = new List<Compra>();

        public int CarritoId { get; set; }
        public int CompraId { get; set; }

        public Cliente()
        {

        }
    }
}