using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestOrigin.Domain.Exceptions;
using TestOrigin.Domain.Interfaces;

namespace TestOrigin.ATM.Controllers
{
    /// <summary>
    /// Controlador de operaciones
    /// </summary>
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private IOperacionesBusiness business;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="business"></param>
        public OperacionController(IOperacionesBusiness business)
        {
            this.business = business;
        }

        /// <summary>
        /// Inserta balance, devuelve true si inserta ok o false si la tarjeta no existe
        /// </summary>
        /// <param name="tarjetId"></param>
        // POST: api/Operacion
        [HttpPost]
        [Route("Balance/Insertar")]
        public bool InsertarBalance(int tarjetId)
        {
            try
            {
                business.InsertarBalance(tarjetId);
                return true;
            }
            catch (BalanceExcedidoException ex)
            {
                Console.Out.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Inserta retiro y devuelve datos de operacion
        /// </summary>
        /// <param name="tarjetId"></param>
        /// <param name="cantidadRetirada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Retiro/Insertar")]
        public bool InsertarRetiro(int tarjetId, decimal cantidadRetirada)
        {
            try
            {
                business.InsertarRetiro(tarjetId, cantidadRetirada);
                return true;
            }
            catch (BalanceExcedidoException ex)
            {
                Console.Out.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
