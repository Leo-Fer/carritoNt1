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
        [Display(Name="DNI")]
        public string Dni { get; set; }

        public List<Carrito> Carritos { get; set; }

        public List<Compra> Compras { get; set; }

    }
}