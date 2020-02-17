using Data.Empresas.Context;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using Microsoft.Extensions.Options;
using Service.Empresas.Services.Abstract;
using Services.Empresas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Util;

namespace Service.Empresas.Services.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly int _size;
        private readonly string _alphabet;
        private readonly IUnitOfWorkAuth _uow;
        private readonly IControlTokenRepository _controlToken;
        private readonly IUserRepository _users;

        public TokenService(IUnitOfWorkAuth uow)
        {
            _uow = uow;
            _users = _uow.Users;
            _size = 4; //TODO: get of AppSetting
            _alphabet = "12341234"; //TODO: get of AppSetting
        }

        public string Generate(int id)
        {
            var user = _users.GetWithKeys(id);
            if (user is null)
                throw new ApiException(HttpStatusCode.NotFound, "User not found.");

            var rand = new Random();
            var hash = new string(Enumerable.Repeat(_alphabet, _size)
                                            .Select(s => s[rand.Next(s.Length)])
                                            .ToArray());

            var controlToken = new ControlToken
            {
                Token = hash,
                SolicitationDate = DateTime.Now,
                AuthenticationDate = null,
                Client = user.Name,
            };
            _uow.Begin();
            controlToken = _uow.ControlToken.Insert(controlToken);
            _uow.Commit();

            return hash;
        }

        public void Validate(string token, int id, bool authenticate)
        {
            var controlToken = GetValidToken(id);

            if (controlToken is null || controlToken.Token != token)
                throw new ApiException(HttpStatusCode.Forbidden,  "Invalid Token");

            if(authenticate)
            {
                controlToken.AuthenticationDate = DateTime.Now;
                _uow.Save();
            }
        }

        private ControlToken GetValidToken(int idUser)
         => _controlToken
            .Query(s => s.Active
                        && s.Id == idUser
                        && s.AuthenticationDate == null,
                 readOnly: true)
            ?.FirstOrDefault();
    }
}
