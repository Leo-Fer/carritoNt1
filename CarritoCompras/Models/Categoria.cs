using System;

namespace CarritoCompras.Models
{

    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Producto Producto { get; set; }
        public Categoria()
        {
        }
    }
}

