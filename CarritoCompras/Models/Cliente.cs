using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{
    public class Cliente : Usuario
    {
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(8, MinimumLength = 5, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
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