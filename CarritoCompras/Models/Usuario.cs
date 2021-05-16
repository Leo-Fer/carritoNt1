using CarritoCompras.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarritoCompras.Models {
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage= ErrorMsgs.ErrorRequerido)]
        [StringLength(15, MinimumLength = 2, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(15, MinimumLength = 2, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(70, MinimumLength = 1, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        // ver como seria el formato para telefonos con codigos raros
        public string Telefono { get; set; }
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMsgs.ErrorRequerido)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = ErrorMsgs.ErrorDeLenght)]
        public string Password { get; set; }
        public string UserRol { get; set; }

    }

    
}
