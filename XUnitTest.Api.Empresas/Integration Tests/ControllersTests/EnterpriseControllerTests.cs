using Api.Empresas.Controllers;
using Data.Empresas.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service.Empresas.Services.Abstract;
using Service.Empresas.Services.Concrete;
using Service.Empresas.Util;
using System;
using Xunit;
using XUnitTest.Api.Empresas.Mocks;

namespace XUnitTest.Api.Empresas.IntegrationTests.ControllerTests
{
    public class EnterpriseControllerTests
    {
        private readonly DbContextOptionsBuilder<EmpresasContext> options 
            = new DbContextOptionsBuilder<EmpresasContext>();
        private EnterpriseController _enterpriseController;
        private IEnterpriseService _enterpriseService;
        private Mock<IEnterpriseService> _acordoServiceMoq;
        private Mock<HttpContext> _context;
        //private readonly MapperFactory mapper = new MapperFactory(MockOptions.GetOptions());
        private string _connectionString = "Server=JOAOGERALDO-PC\\MSSQLSERVER01;Database=EmpresasDB;Trusted_Connection=True;MultipleActiveResultSets=true;";


        public EnterpriseControllerTests()
        {
            _acordoServiceMoq = new Mock<IEnterpriseService>();
            _enterpriseController = new EnterpriseController(_acordoServiceMoq.Object);
            _context = new Mock<HttpContext>();
        }

        // integration test
        [Fact]
        public void GetEnterprisesTest()
        {
            using (var context = new EmpresasContext(options.UseInMemoryDatabase("GetEnterprises_all").Options))
            {
                context.Database.EnsureCreated();
               // IEnterpriseService enterpriseService = new EnterpriseService(context, mapper);
            }
        }
    }
}
