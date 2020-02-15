using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Services.Abstract
{
    public interface IEnterpriseFacade
    {
        EnterpriseListOutput Enterprises(EnterpriseFilter filter);
        EnterpriseListOutput GetEnterprise(long id); 

    }
}
