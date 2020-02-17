using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Data.Empresas.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Empresas.Repositories;
using Data.Empresas.Repositories;
using Domain.Empresas.Entities;
using AutoMapper;
using Service.Empresas.Services.Concrete;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Empresas.Services.Abstract;
using Domain.Empresas.Unities;
using Data.Empresas.UnitOfWork;
using Service.Empresas.Util;
using Service.Empresas.MapperFactories;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Empresas
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=JOAOGERALDO-PC\\MSSQLSERVER01;Database=EmpresasDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
            //var connectionString = Configuration.GetConnectionString("EmpresasContext");
            services
                .AddHttpContextAccessor()
                .AddDbContext<EmpresasContext>(opts =>
                    opts.UseSqlServer(connectionString))

                .AddDbContext<EmpresasContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("EmpresasContext")))
                .AddScoped<IRepository<Enterprise>, Repository<Enterprise>>()
                .AddScoped<IRepository<EnterpriseType>, Repository<EnterpriseType>>()
                .AddScoped<IEnterpriseRepository, EnterpriseRepository>()
                .AddScoped<IEnterpriseTypeRepository, EnterpriseTypeRepository>()
                .AddScoped<IControlTokenRepository, ControlTokenRepository>()
                .AddScoped<IUnitOfWorkEnterprises, UnitOfWorkEnterprise>()
                .AddScoped<IUnitOfWorkAuth, UnitOfWorkAuth>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IControlTokenRepository, ControlTokenRepository>()
                .AddScoped<IEnterpriseService, EnterpriseService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITokenService, TokenService>()
                .AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // automapper services and profiles
            IServiceProvider provider = services.BuildServiceProvider();
            services
                .AddSingleton<MapperFactory>()
                .AddScoped(x => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ProfileToInput(provider.GetRequiredService<IUnitOfWorkEnterprises>()));
                    cfg.AddProfile(new ProfileToOutput());
                }).CreateMapper())
                .AddAutoMapper(typeof(EnterpriseService));

            // JWT - Authenticate
            var rawKey = "12345678909876543";/*Configuration["Keys:rawKey"]*/
            var key = Encoding.UTF8.GetBytes(rawKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app
                .UseMiddleware<ExceptionMiddleware>()
                .UseAuthentication()
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
