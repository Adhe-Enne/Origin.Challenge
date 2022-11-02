using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Origin.Business.Constants
{
    public static class CardMessages
    {
        public const string ERROR_ACCESS = "No es posible acceder a esta tarjeta, Razon: ";

        public const string NO_ATTEMPS = "Tarjeta Bloqueada por varios intentos";
        public const string INSUFICIENT_FUNDS = "Saldo Insuficiente";
        public const string EMPTY_FUNDS = "FONDOS AGOTADOS";
        public const string NONEXISTENT_CARD= "No existe en registro";
        public const string UNBALANCED_CARD = "No se encuentra en BALANCE";
        public const string INVALID_PIN = "¡El PIN ingresado es incorrecto!";
        public const string EXPIRED_CARD = "La tarjeta ha Caducado, Fecha: ";
        public const string WARNING_BALANCED = "TARJETA EN BALANCE";
        public const string WARNING_ACCESS = "Su tarjeta esta a punto de ser Bloqueada";

        public const string CARD_HASBEEN_LOCKED= "Su Tarjeta ha sido Bloqueada";

        public const string CARD_HASBEEN_BALANCED = "Tarjeta Disponible en BALANCE";
        public const string CARD_WITHDRAW = "Extraccion exitosa";

        public const string CARD_LOCKED = "TARJETA BLOQUEADA";

    }
}
