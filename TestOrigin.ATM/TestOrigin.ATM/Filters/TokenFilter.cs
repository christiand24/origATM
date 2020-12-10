using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestOrigin.Domain.Const;

namespace TestOrigin.ATM.Filters
{
    public class TokenFilter: AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Headers.TryGetValue(Sistema.TOKEN_NAME, out var token) || token != Sistema.MAGIC_TOKEN)
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }
    }
}
