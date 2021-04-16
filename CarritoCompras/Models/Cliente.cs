using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace CarritoCompras.Models
{
    public class Cliente : Usuario
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public List<Carrito> Carritos { get; set; } = new List<Carrito>();
        public List<Compra> Compras { get; set; } = new List<Compra>();
=======
public class Cliente : Usuario
{
    public int Id { get; set; }
    public string Dni { get; set; }
    public List<Carrito> Carritos { get; set; }
    public List<Compra> Compras { get; set; }


>>>>>>> aeb43cac8e279f48b3b4723dab4c5f3b94e2fea2

        public Cliente()
        {
        }
    }
}