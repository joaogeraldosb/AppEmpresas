using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Util;
using Microsoft.Extensions.Logging;

namespace Api.Empresas
{
    /// <summary>
    /// Classe global para tratamento de erros
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate requestDelegate
                                    , ILoggerFactory logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger.CreateLogger("Global Errors");
        }

        /// <summary>
        /// Global try-catch
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (ApiException ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.LogInfo))
                    _logger.LogWarning(ex.LogInfo);

                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
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
