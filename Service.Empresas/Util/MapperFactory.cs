using AutoMapper;
using Domain.Empresas.ComplexTypes;
using Domain.Empresas.Entities;
using Microsoft.Extensions.Options;
using Service.Empresas.DTOs.Enterprises.Inputs;
using Service.Empresas.DTOs.Enterprises.Outputs;
using Services.Empresas.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Empresas.Util
{
    /// <summary>
    /// Mapper settings
    /// </summary>
    public class MapperFactory
    {
        private readonly ApplicationSettings _settings;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="settings"></param>
        public MapperFactory(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        public IMapper EnterpriseMapper
        {
            get 
            {
                return new MapperConfiguration(config =>
                {
                    config.CreateMap<EnterpriseFilter, Enterprise>()
                    .ForMember(m => m.Contact,
                                opts => opts.MapFrom(s => new Contact(s.ContactName, s.Phone, s.CellPhone, s.Email)));
                    config.CreateMap<EnterpriseType, EnterpriseTypeOutput>();
                           
                }).CreateMapper();
            }
        }
    }
}
