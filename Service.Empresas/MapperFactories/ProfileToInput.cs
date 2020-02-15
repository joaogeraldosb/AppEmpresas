using AutoMapper;
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

            CreateMap<EnterpriseFilter, Enterprise>()
                    .ForMember(m => m.Contact,
            opts => opts.MapFrom(s => new Contact(s.ContactName, s.Phone, s.CellPhone, s.Email)));
            
            CreateMap<EnterpriseType, EnterpriseTypeOutput>();

        }
    }
}
