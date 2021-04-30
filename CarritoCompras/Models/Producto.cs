using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(25, MinimumLength = 2, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(140, MinimumLength = 10, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public double PrecioVigente { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public bool Activo { get; set; }
        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

        public Producto()
        {
        }
    }
}