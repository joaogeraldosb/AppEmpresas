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
        private readonly IEnterpriseService _service;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="service"></param>
        public EnterpriseController(IEnterpriseService service) => 
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
            if(!enterprices.Any())
                return NoContent();

            return Ok(enterprices);
        }

        /// <summary>
        /// Get Enterprices
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromQuery]int id)
        {
            var enterprice = _service.GetEnterprise(id);
            if (enterprice is null)
                return NoContent();

            return Ok(enterprice);
        }
    }
}