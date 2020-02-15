using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Service.Empresas.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Services.Concrete
{
    public class EnterpriseService : IEnterpriseFacade
    {
        public EnterpriseListOutput Enterprises(EnterpriseFilter filter)
        {
            throw new NotImplementedException();
        }

        public EnterpriseListOutput GetEnterprise(long id)
        {
            throw new NotImplementedException();
        }
    }
}
