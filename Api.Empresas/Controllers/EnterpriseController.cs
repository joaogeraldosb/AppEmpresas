using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Empresas.FilterAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.Services.Abstract;

namespace Api.Empresas.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ValidateModelState]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseFacade _service;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="service"></param>
        public EnterpriseController(IEnterpriseFacade service) => 
            _service = service;

        /// <summary>
        /// Get Enterprices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery]EnterpriseFilter input)
        {
            var enterprices = _service.Enterprises(input);
            return Ok(enterprices);
        }
    }
}