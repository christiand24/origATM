using System;
using System.Collections.Generic;
using System.Text;
using TestOrigin.Domain.Entities;
using TestOrigin.Domain.Results;

namespace TestOrigin.Domain.Interfaces
{
    public interface ITarjetaBusiness
    {
        /// <summary>
        /// Recupera una tarjeta
        /// </summary>
        /// <param name="tarjetaId"></param>
        /// <returns></returns>
        Tarjeta Traer(int tarjetaId);
        /// <summary>
        /// Devuelve Codigo = 0 si la tarjeta existe y no esta bloqueada, de lo contrario Codigo = 1 y mensaje de error
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns></returns>
        BusinessResult EsTarjetaOperativa(string numeroTarjeta);
        /// <summary>
        /// Si el pin es correcto devuelve el ID de tarjeta sino -1
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="PIN"></param>
        /// <returns></returns>
        int ValidarPIN(string numeroTarjeta, int PIN);
    }
}
