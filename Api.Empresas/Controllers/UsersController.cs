using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Empresas.FilterAttributes;
using AutoMapper;
using Domain.Empresas.Entities;
using Domain.Empresas.Unities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Service.Empresas.Services.Abstract;

namespace Api.Empresas.Controllers
{
    /// <summary>
    /// User endpoints
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ValidateModelState]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWorkAuth _uow;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="tokenService"></param>
        /// <param name="mapper"></param>
        public UsersController(IUnitOfWorkAuth uow
            , ITokenService tokenService
            , IMapper mapper)
        {
            _uow = uow;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("auth/sign_in")]
        [AllowAnonymous]
        public IActionResult AuthenticateUser(CredentialInput credentialInput)
        {
            var userInput = new UserInput(credentialInput.Email, credentialInput.Password);

            var hasher = new SHA512Managed();
            var password = hasher.ComputeHash(Encoding.UTF8.GetBytes(credentialInput.Password));

            var user = _mapper.Map<User>(userInput);

            var jwtHandler = new JwtSecurityTokenHandler();
            var rawKey = "12345678909876543";/*Configuration["Keys:rawKey"]*/
            var key = Encoding.UTF8.GetBytes(rawKey);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Name", user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var credentialToken = new CredentialTokenOutput
            { 
                Id = user.Id,
                AccessToken = jwtHandler.WriteToken(jwtHandler.CreateToken(securityTokenDescriptor)),
                Client = ""
            };
            return Ok(credentialToken);
        }


        private int GetUserIdFromRequestToken()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return int.Parse(claims?.FindFirst("Id")?.Value);
        }
    }
}