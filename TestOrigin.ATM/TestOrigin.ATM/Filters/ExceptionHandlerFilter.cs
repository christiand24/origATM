using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestOrigin.ATM.Filters
{
    /// <summary>
    /// Atrapa las excepciones del sistema y las graba a un log
    /// </summary>
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        /// <summary>
        /// graba la excepcion
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            //Aca se puede guardar la excepcion a un log implemetado por log4net

            Console.Out.Write(context.Exception.Message);
        }
    }
}
