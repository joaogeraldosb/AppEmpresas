﻿using AutoMapper;
using Data.Empresas.Repositories;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Service.Empresas.Services.Abstract;
using Service.Empresas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Empresas.Services.Concrete
{
    public class EnterpriseService : IEnterpriseService
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

        public List<EnterpriseIndexOutput> Enterprises(EnterpriseFilter filter)
        {
            var filterObject = _mapper.Map<Enterprise>(filter);
            var query = _enterprises.Query(
                e => e.Active,
                readOnly: true,
                included: $"{nameof(Enterprise.EnterpriseType)}");

            query = query.Where(e => (filterObject.Name == e.Name || filter.Name == null)
                && (filterObject.IdEnterpriseType == e.IdEnterpriseType || filter.IdEnterpriseType == null));

            var enterprises = query.ToList();
            return _mapper.Map<List<EnterpriseIndexOutput>>(enterprises);
        }

        public EnterpriseDetailOutput GetEnterprise(int id)
        {
            var enterprise = _enterprises.GetWithKeys(id);
            return _mapper.Map<EnterpriseDetailOutput>(enterprise);
        }
    }
}
