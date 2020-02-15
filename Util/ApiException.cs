using System;
using System.Net;

namespace Util
{
    /// <summary>
    /// Class to simulate HttpException of the .Net Framework
    /// </summary>
    public class ApiException : Exception
    {
        #region ApiException
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpStatusCode"></param>
        public ApiException(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
        #endregion

        /// <summary>
        /// Error of api
        /// </summary>
        public readonly ApiError Error;

        /// <summary>
        /// Status Code to return
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Message to be logged
        /// </summary>
        public readonly string LogInfo;


        #region ApiError
        /// <summary>
        /// Error of api
        /// </summary>
        public class ApiError
        {
#pragma warning disable CS8618 // O campo não nulo é não inicializado.
            /// <summary>
            /// Code of error
            /// </summary>
            public int CdErro { get; set; }
            /// <summary>
            /// Message of error
            /// </summary>
            public string MsgErro { get; set; }
#pragma warning restore CS8618 // O campo não nulo é não inicializado.
            #endregion

        }
    }
}