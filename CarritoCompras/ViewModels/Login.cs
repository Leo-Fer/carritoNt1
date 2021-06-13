using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.ViewModels
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public bool Recordarme { get; set; }
    }
}
