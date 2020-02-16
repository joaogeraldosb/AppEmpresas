using Domain.Empresas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Empresas.Repositories
{
    public interface IUserRepository
    {
        User LoadNavigation(User enterprise, Expression<Func<Enterprise, object>> expression);
        User LoadCollection(Enterprise enterprise, string collectionPropName);
        User GetWithKeys(long id);
        User GetWithKeys(long id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null);
        IQueryable<User> GetAll(bool readOnly = false);
        IQueryable<User> GetAll(string included = "", bool readOnly = false);
        User Insert(User entity);
        User Remove(User entity);
        User Remove(long id);
        IQueryable<User> Query(Expression<Func<User, bool>> predicate = null, bool readOnly = false, string included = "");
    }
}
