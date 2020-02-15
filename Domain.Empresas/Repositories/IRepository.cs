using Domain.Empresas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Empresas.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T LoadNavigation(T e, Expression<Func<T, object>> expression);
        T LoadCollection(T e, string propName);
        T GetWithKeys(params object[] keys);
        T GetWithKeys(object[] keys, IEnumerable<string> navigations = null, IEnumerable<string> collections = null);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate = null, bool readOnly = false, string included = "");
        IQueryable<S> Query<S>(Expression<Func<S, bool>> predicate = null, bool readOnly = false, string included = "") where S : T;

        IQueryable<T> GetAll(bool readOnly = false);
        IQueryable<T> GetAll(string included = "", bool readOnly = false);
        T Insert(T entity);
        IEnumerable<T> InsertMany(IEnumerable<T> entities);

        T Remove(T entity);
        T Remove(params object[] keys);
        IEnumerable<T> RemoveMany(IEnumerable<T> entities);

        IEnumerable<T> RemoveMany(IEnumerable<object[]> keys);

    }
}
