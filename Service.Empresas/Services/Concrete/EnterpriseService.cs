using AutoMapper;
using Data.Empresas.Repositories;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Service.Empresas.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Empresas.Services.Concrete
{
    public class EnterpriseService : IEnterpriseFacade
    {
        private readonly IUnitOfWorkEnterprises _uow;
        private readonly IEnterpriseRepository _enterprises;
        private readonly IEnterpriseTypeRepository _types;
        private readonly IMapper _mapper;

        public EnterpriseService(IUnitOfWorkEnterprises uow, IMapper mapper)
        {
            _uow = uow;
            _enterprises = uow.Enterprises;
            _types = uow.Types;
            _mapper = mapper;
        }

        public EnterpriseListOutput Enterprises(EnterpriseFilter filterEnterprise)
        {
            var filterObject = _mapper.Map<Enterprise>(filterEnterprise);
            var query = _enterprises.Query(
                e => e.Active,
                readOnly: true,
                included: $"{nameof(Enterprise.EnterpriseType)}");

            // required filters
            query = query.Where(e => filterObject.Name == e.Name || filterEnterprise.Name == null);
            query = query.Where(e => filterObject.IdEnterpriseType == e.IdEnterpriseType || filterEnterprise.EnterpriseTypeId == null);

            // aditional filters. poorly made. not discovered yet a simpler and better way to enable all properties as filters but checking each one
            query = query.Where(e => filterObject.Contact.Phone == e.Contact.Phone || filterEnterprise.Phone == null);
            query = query.Where(e => filterObject.Contact.CellPhone == e.Contact.CellPhone || filterEnterprise.CellPhone == null);

            return _mapper.Map<EnterpriseListOutput>(query.ToList());
        }

        public EnterpriseDetailListOutput GetEnterprise(long id)
        {
            var enterprise = _mapper.Map<Enterprise>(id);
            return _mapper.Map<EnterpriseDetailListOutput>(enterprise);
        }

    }
}
