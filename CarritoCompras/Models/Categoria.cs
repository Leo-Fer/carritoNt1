using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{

    public class Categoria
    {
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Producto> Productos;

        public Categoria()
        {
        }
    }
}

