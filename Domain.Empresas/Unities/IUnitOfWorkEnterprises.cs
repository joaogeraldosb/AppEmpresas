using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Unities
{
    public interface IUnitOfWorkEnterprises : IUnitOfWork
    {
        IEnterpriseRepository Enterprises { get; }
        IEnterpriseTypeRepository Types { get; }
    }
}
