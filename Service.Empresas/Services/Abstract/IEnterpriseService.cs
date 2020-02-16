using Domain.Empresas.Entities;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Services.Abstract
{
    public interface IEnterpriseService
    {
        List<EnterpriseDetailListOutput> Enterprises(EnterpriseFilter filter);
        EnterpriseDetailOutput GetEnterprise(long id);
    }
}
