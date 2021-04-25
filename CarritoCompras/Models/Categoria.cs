using System;
using System.Collections.Generic;

namespace CarritoCompras.Models
{

    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Producto> Producto;

        public Categoria()
        {
        }
    }
}

