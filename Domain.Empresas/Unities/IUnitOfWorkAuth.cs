using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Unities
{
    public interface IUnitOfWorkAuth : IUnitOfWork
    {
        IControlTokenRepository ControlToken { get; }
        IUserRepository Users { get; }
    }
}
