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
    //[ApiController]
    //[Route("api/v1/[controller]")]
    //[Produces("application/json")]
    [ApiController, Route("api/v1/[controller]"), Produces("application/json")]
    [ValidateModelState]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseFacade _service;

        public EnterpriseController(IEnterpriseFacade service) => _service = service;

        [HttpGet]
        public IActionResult Get([FromQuery]EnterpriseFilter input)
        {
            return Ok(_service.Enterprises(input));
        }
    }
}