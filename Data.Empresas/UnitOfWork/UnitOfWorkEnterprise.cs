using System;
using System.Collections.Generic;
using System.Text;
using Data.Empresas.Context;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;

namespace Data.Empresas.UnitOfWork
{
    public class UnitOfWorkEnterprise : UnitOfWork, IUnitOfWorkEnterprises
    {
        public UnitOfWorkEnterprise(EmpresasContext context
            , IEnterpriseRepository enterpriseRepository
            , IEnterpriseTypeRepository enterpriseTypeRepository)
                : base(context)
        {
            Enterprises = enterpriseRepository;
            Types = enterpriseTypeRepository;
        }

        public IEnterpriseRepository Enterprises { get; }

        public IEnterpriseTypeRepository Types { get; }
    }
}
