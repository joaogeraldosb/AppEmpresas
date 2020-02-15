using AutoMapper;
using Domain.Empresas.Entities;
using Service.Empresas.DTOs.Enterprises.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.MapperFactories
{
    public class ProfileToOutput : Profile
    {
        public ProfileToOutput()
        {
            CreateMap<EnterpriseType, EnterpriseTypeOutput>();
            CreateMap<Enterprise, EnterpriseDetailOutput>();

            CreateMap<Enterprise, EnterpriseDetailListOutput>()
                .ForMember(dest => dest.Enterprise,
                           opts => opts.MapFrom(src => new EnterpriseDetailOutput(src)));
        }
    }
}
