using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Empresas.Repositories
{
    public class ControlTokenRepository : IControlTokenRepository
    {
        private readonly IRepository<ControlToken> _baseRepository;

        public ControlTokenRepository(IRepository<ControlToken> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<ControlToken> GetAll(bool readOnly = false)
        {
            return _baseRepository.GetAll(readOnly);
        }

        public IQueryable<ControlToken> GetAll(string included = "", bool readOnly = false)
        {
            return _baseRepository.GetAll(included, readOnly);
        }

        public ControlToken GetWithKeys(long id)
        {
            return _baseRepository.GetWithKeys(id);
        }

        public ControlToken GetWithKeys(long id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null)
        {
            return _baseRepository.GetWithKeys(new[] { (object)id }, navigations: navigations, collections: collections);
        }

        public ControlToken Insert(ControlToken entity)
        {
            return _baseRepository.Insert(entity);
        }

        public ControlToken LoadCollection(ControlToken enterprise, string collectionPropName)
        {
            return _baseRepository.LoadCollection(enterprise, collectionPropName);
        }

        public ControlToken LoadNavigation(ControlToken enterprise, Expression<Func<ControlToken, object>> expression)
        {
            return _baseRepository.LoadNavigation(enterprise, expression);
        }

        public ControlToken Remove(ControlToken entity)
        {
            return _baseRepository.Remove(entity);
        }

        public ControlToken Remove(long id)
        {
            return _baseRepository.Remove(id);
        }
        public IQueryable<ControlToken> Query(Expression<Func<ControlToken, bool>> predicate = null, bool readOnly = false, string included = "")
        {
            return _baseRepository.Query(predicate, readOnly, included);
        }

        public ControlToken LoadNavigation(ControlToken enterprise, Expression<Func<Enterprise, object>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
