using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Empresas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _baseRepository;

        public UserRepository(IRepository<User> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<User> GetAll(bool readOnly = false)
        {
            return _baseRepository.GetAll(readOnly);
        }

        public IQueryable<User> GetAll(string included = "", bool readOnly = false)
        {
            return _baseRepository.GetAll(included, readOnly);
        }

        public User GetWithKeys(long id)
        {
            return _baseRepository.GetWithKeys(id);
        }

        public User GetWithKeys(long id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null)
        {
            return _baseRepository.GetWithKeys(new[] { (object)id }, navigations: navigations, collections: collections);
        }

        public User Insert(User entity)
        {
            return _baseRepository.Insert(entity);
        }

        public User LoadCollection(User enterprise, string collectionPropName)
        {
            return _baseRepository.LoadCollection(enterprise, collectionPropName);
        }

        public User LoadNavigation(User enterprise, Expression<Func<User, object>> expression)
        {
            return _baseRepository.LoadNavigation(enterprise, expression);
        }

        public User Remove(User entity)
        {
            return _baseRepository.Remove(entity);
        }

        public User Remove(long id)
        {
            return _baseRepository.Remove(id);
        }
        public IQueryable<User> Query(Expression<Func<User, bool>> predicate = null, bool readOnly = false, string included = "")
        {
            return _baseRepository.Query(predicate, readOnly, included);
        }

        public User LoadNavigation(User enterprise, Expression<Func<Enterprise, object>> expression)
        {
            throw new NotImplementedException();
        }

        public User LoadCollection(Enterprise enterprise, string collectionPropName)
        {
            throw new NotImplementedException();
        }
    }
}
