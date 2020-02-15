using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Util;

namespace Api.Empresas.FilterAttributes
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if(!modelState.IsValid)
            {
                throw new ApiException(HttpStatusCode.BadRequest
                    , string.Join(" | ", modelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)));
            }
            base.OnActionExecuting(context);
        }
    }
}
