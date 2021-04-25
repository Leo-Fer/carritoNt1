using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public double PrecioVigente { get; set; }
        public bool Activo { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public Categoria Categoria { get; set; }
        
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        public int CategoriaId { get; set; }

        public Producto()
        {
        }
    }
}