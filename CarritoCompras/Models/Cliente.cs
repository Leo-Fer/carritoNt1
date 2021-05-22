using CarritoCompras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models
{
    public class Cliente : Usuario
    {
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [Range(1000000,99999999, ErrorMessage = ErrorMsgs.ErrorDeRange)]
        public string Dni { get; set; }

        public List<Carrito> Carritos;

        public List<Compra> Compras;

        public Carrito carrito { get; set; }



    }
}