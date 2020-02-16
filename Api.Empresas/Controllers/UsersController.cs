using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Empresas.Services.Abstract;

namespace Api.Empresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public UsersController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        private int GetUserIdFromRequestToken()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return int.Parse(claims?.FindFirst("Id")?.Value);
        }
    }
}