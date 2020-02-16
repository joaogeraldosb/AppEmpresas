using AutoMapper;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Service.Empresas.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkAuth _uow;
        private readonly IUserRepository _users;
        private readonly IControlTokenRepository _controlToken;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWorkAuth uow
            , IMapper mapper)
        {
            _uow = uow;
            _users = uow.Users;
            _controlToken = uow.ControlToken;
            _mapper = mapper;
        }

        public UserOutput GetUser(long id)
        {
            var user = _users.GetWithKeys(id);
            return _mapper.Map<UserOutput>(user);
        }

        public UserOutput PostUser(UserInput userInput)
        {
            var user    = _mapper.Map<User>(userInput);
            user        = _users.Insert(user);
            _uow.Save();

            return _mapper.Map<UserOutput>(user);
        }
    }
}
