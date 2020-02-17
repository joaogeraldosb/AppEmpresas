using AutoMapper;
using Domain.Empresas.ComplexTypes;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Domain.Empresas.Unities;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.MapperFactories
{
    public class ProfileToInput : Profile
    {
        private readonly IEnterpriseRepository enterprises;
        private readonly IEnterpriseTypeRepository types;

        public ProfileToInput(IUnitOfWorkEnterprises uow)
        {
            enterprises = uow.Enterprises;
            types = uow.Types;

            CreateMap<EnterpriseFilter, Enterprise>();
            
            CreateMap<EnterpriseType, EnterpriseTypeOutput>();

        }
    }
}
