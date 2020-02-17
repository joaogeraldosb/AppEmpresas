using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Empresas.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly IRepository<Enterprise> _baseRepository;

        public EnterpriseRepository(IRepository<Enterprise> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<Enterprise> GetAll(bool readOnly = false)
        {
            return _baseRepository.GetAll(readOnly);
        }

        public IQueryable<Enterprise> GetAll(string included = "", bool readOnly = false)
        {
            return _baseRepository.GetAll(included, readOnly);
        }

        public Enterprise GetWithKeys(int id)
        {
            return _baseRepository.GetWithKeys(id);
        }

        public Enterprise GetWithKeys(int id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null)
        {
            return _baseRepository.GetWithKeys(new[] { (object)id }, navigations: navigations, collections: collections);
        }

        public Enterprise Insert(Enterprise entity)
        {
            return _baseRepository.Insert(entity);
        }

        public Enterprise LoadCollection(Enterprise enterprise, string collectionPropName)
        {
            return _baseRepository.LoadCollection(enterprise, collectionPropName);
        }

        public Enterprise LoadNavigation(Enterprise enterprise, Expression<Func<Enterprise, object>> expression)
        {
            return _baseRepository.LoadNavigation(enterprise, expression);
        }

        public Enterprise Remove(Enterprise entity)
        {
            return _baseRepository.Remove(entity);
        }

        public Enterprise Remove(int id)
        {
            return _baseRepository.Remove(id);
        }
        public IQueryable<Enterprise> Query(Expression<Func<Enterprise, bool>> predicate = null, bool readOnly = false, string included = "")
        {
            return _baseRepository.Query(predicate, readOnly, included);
        }

    }
}
