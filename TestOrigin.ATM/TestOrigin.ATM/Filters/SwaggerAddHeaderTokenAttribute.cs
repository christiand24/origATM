using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TestOrigin.Domain.Const;

namespace TestOrigin.ATM.Filters
{
    /// <summary>
    /// Sumar parametro en el header de swagger para que pase el token de validacion, en este caso
    /// como es una prueba pasa por defecto un valor por defecto para no tener que ingresar el mismo a cada rato
    /// </summary>
    public class SwaggerAddHeaderTokenAttribute: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = Sistema.TOKEN_NAME,
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Default = new OpenApiString("DFGHFDGHGFHHFHFH")
                }
            });
        }
    }
}
