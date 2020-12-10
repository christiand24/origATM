using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestOrigin.ATM.Model;
using TestOrigin.Domain.Exceptions;
using TestOrigin.Domain.Interfaces;
using TestOrigin.Domain.Results;
using TestOrigin.ATM.Mappers;

namespace TestOrigin.ATM.Controllers
{
    /// <summary>
    /// Controlador de tarjeta
    /// </summary>
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private ITarjetaBusiness business;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="business"></param>
        public TarjetaController(ITarjetaBusiness business)
        {
            this.business = business;
        }

        /// <summary>
        /// Recupera tarjeta
        /// </summary>
        /// <param name="tarjetaId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Traer")]
        public TarjetaVM Traer(int tarjetaId)
        {
            return business.Traer(tarjetaId).ToTarjetaVM();
        }

        /// <summary>
        /// Valida si tj esta operativa
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EsTarjetaOperativa")]
        public BusinessResult EsTarjetaOperativa(string numeroTarjeta)
        {
            return business.EsTarjetaOperativa(numeroTarjeta);
        }

        // GET: api/Tarjeta/5
        /// <summary>
        /// Devuelve ID tarjeta si esta ok, -1: pin incorrecto, -2: tarjeta bloqueada
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="PIN"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ValidarPIN")]
        public int ValidarPIN(string numeroTarjeta, int PIN)
        {

            try
            {
                return business.ValidarPIN(numeroTarjeta, PIN);
            }
            catch (TarjetaBloqueadaException ex)
            {
                Console.Out.WriteLine(ex.Message);
                return -2;
            }
        }

    }
}
