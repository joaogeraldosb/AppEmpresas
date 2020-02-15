using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Util;

namespace Api.Empresas
{
    /// <summary>
    /// Classe global para tratamento de erros
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate RequestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate) =>
            RequestDelegate = requestDelegate;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await RequestDelegate(httpContext);
            }
            catch (ApiException ex)
            {
                //if (!string.IsNullOrWhiteSpace(ex.LogInfo))
                //{
                //    Logger.LogWarning(ex.LogInfo);
                //}

                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex.Message);
                await HandleExceptionAsync(httpContext);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                status = $"{(int)HttpStatusCode.InternalServerError}",
                error = "Erro inesperado. Entre em contato com o administrador do sistema."
            }));
        }

        private Task HandleExceptionAsync(HttpContext context, ApiException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                status = $"{(int)exception.StatusCode}",
                error = exception.Message
            }));
        }


    }
}
