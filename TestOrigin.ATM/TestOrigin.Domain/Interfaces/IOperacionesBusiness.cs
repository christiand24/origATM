using System;
using System.Collections.Generic;
using System.Text;

namespace TestOrigin.Domain.Interfaces
{
    public interface IOperacionesBusiness
    {
        /// <summary>
        /// Inserta un registro en balance
        /// </summary>
        /// <param name="tarjetId"></param>
        void InsertarBalance(int tarjetId);
        /// <summary>
        /// Inserta un registro en retiro
        /// </summary>
        /// <param name="tarjetId"></param>
        /// <param name="cantidadRetirada"></param>
        void InsertarRetiro(int tarjetId, decimal cantidadRetirada);
    }
}
