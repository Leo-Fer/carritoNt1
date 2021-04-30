using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoCompras.Data
{
    public static class ErrorMsgs
    {
        public const string ErrorRequerido = "El campo {0} es obligatorio.";
        public const string ErrorDeLenght = "Para el campo {0} debe estar comprendido entre {2} y {1}";
        public const string ErrorDeRange = "Para el campo {0} debe estar comprendido entre los rangos {1} y {2}";
        public const string ErrorMenorACero = "El campo {0} debe ser mayor a cero.";
        public const string ErrorValorNegativo = "El campo {0} debe ser mayor o igual a cero.";
    }
}
