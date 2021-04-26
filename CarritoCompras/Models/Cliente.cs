using System;
using System.Collections.Generic;

namespace CarritoCompras.Models
{
    public class Cliente : Usuario
    {
        public string Dni { get; set; }

        public List<Carrito> Carritos;

        public List<Compra> Compras;

        public int CarritoId { get; set; }
        public int CompraId { get; set; }

        public Cliente()
        {

        }
    }
}