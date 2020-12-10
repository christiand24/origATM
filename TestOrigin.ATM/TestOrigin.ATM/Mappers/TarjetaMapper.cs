using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOrigin.ATM.Model;
using TestOrigin.Domain.Entities;

namespace TestOrigin.ATM.Mappers
{
    /// <summary>
    /// Convierto clase Tarjeta a TarjetaVM (se podria usar automapper pero como es solo una clase no vale la pena)
    /// </summary>
    public static class TarjetaMapper
    {
        /// <summary>
        /// Convierte Tarjeta a TarjetaVM
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TarjetaVM ToTarjetaVM(this Tarjeta source)
        {
            return new TarjetaVM() { Balance = source.Balance, FechaVencimiento = source.FechaVencimiento, Numero = source.Numero };

        }
    }
}
