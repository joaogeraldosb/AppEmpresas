using Data.Empresas.Context;
using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Empresas.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private EmpresasContext Context { get; set; }
        protected virtual DbSet<T> EntitiesSet { get; set; }

        public Repository(EmpresasContext context)
        {
            Context = context;
            EntitiesSet = Context.Set<T>();
        }

        public IQueryable<T> GetAll(bool readOnly = false)
        {
            return readOnly ? EntitiesSet.AsNoTracking() : EntitiesSet;
        }

        public IQueryable<T> GetAll(string included = "", bool readOnly = false)
        {
            return Query(m => true, readOnly, included);
        }

        public T GetWithKeys(params object[] keys)
        {
            return EntitiesSet.Find(keys);
        }

        public T GetWithKeys(object[] keys, IEnumerable<string> navigations = null, IEnumerable<string> collections = null)
        {
            var entity = GetWithKeys(keys);

            return entity;
        }

        public virtual T Insert(T entity)
        {
            return EntitiesSet.Add(entity).Entity;
        }

        public T LoadCollection(T e, string propName)
        {
            Context.Entry(e).Collection(propName).Load();
            return e;
        }

        public T LoadNavigation(T e, Expression<Func<T, object>> expression)
        {
            Context.Entry(e).Reference(expression).Load();
            return e;
        }

        public virtual T Remove(T entity)
        {
            return EntitiesSet.Remove(entity).Entity;
        }

        public T Remove(params object[] keys)
        {
            return EntitiesSet.Remove(EntitiesSet.Find(keys)).Entity;
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate = null, bool readOnly = false, string included = "")
        {
            return Query<T>(predicate, readOnly, included);
        }

        public virtual IQueryable<S> Query<S>(Expression<Func<S, bool>> predicate = null, bool readOnly = false, string included = "") where S : T
        {
            var query = included
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(EntitiesSet.OfType<S>(), (set, navigation) => set.Include(navigation))
                .Where(predicate ?? (e => true));

            return readOnly ? query.AsNoTracking() : query;
        }

        public IEnumerable<T> InsertMany(IEnumerable<T> entities)
        {
            EntitiesSet.AddRange(entities);
            return entities;
        }

        public IEnumerable<T> RemoveMany(IEnumerable<T> entities)
        {
            EntitiesSet.RemoveRange(entities);
            return entities;
        }

        public IEnumerable<T> RemoveMany(IEnumerable<object[]> keys)
        {
            foreach (var key in keys)
            {
                yield return Remove(key);
            }
        }
    }
}
