using CarritoCompras.Data;
using System;
using System.Collections.Generic;
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
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = ErrorMsgs.ErrorMenorACero)]
        [Display(Name ="Precio unitario")]
        public double PrecioVigente { get; set; }

        public bool Activo { get; set; } = true;
        
        public Categoria Categoria { get; set; }
        [Display(Name ="Categoria")]
        [Required]
        public int CategoriaId { get; set; }
        
        public List<StockItem> Stockitems { get; set; }

    }
}