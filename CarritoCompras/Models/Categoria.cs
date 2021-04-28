using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{

    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(140, MinimumLength = 10, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Descripcion { get; set; }

        public List<Producto> Productos;

        public Categoria()
        {
        }
    }
}

