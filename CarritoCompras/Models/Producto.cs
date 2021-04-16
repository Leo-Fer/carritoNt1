using System;

<<<<<<< HEAD
namespace CarritoCompras.Models {
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVigente { get; set; }
        public bool Activo { get; set; }
=======
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double PrecioVigente { get; set; }
    public bool Activo { get; set; }
>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2

        public Categoria Categoria { get; set; }
        public Producto()
        {
        }
    }
}