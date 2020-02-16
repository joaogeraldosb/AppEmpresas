using Data.Empresas.Context;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Empresas.UnitOfWork
{
    public class UnitOfWorkAuth : UnitOfWork, IUnitOfWorkAuth
    {
        public UnitOfWorkAuth(EmpresasContext context
            , IControlTokenRepository controlTokenRepository
            , IUserRepository userRepository)
                : base(context)
        {
            ControlToken = controlTokenRepository;
            Users = userRepository;
        }

        public IControlTokenRepository ControlToken { get; }

        public IUserRepository Users { get; }
    }
}
