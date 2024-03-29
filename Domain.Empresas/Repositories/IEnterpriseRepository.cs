﻿using Domain.Empresas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Empresas.Repositories
{
    public interface IEnterpriseRepository
    {
        Enterprise LoadNavigation(Enterprise enterprise, Expression<Func<Enterprise, object>> expression);

        Enterprise LoadCollection(Enterprise enterprise, string collectionPropName);
        Enterprise GetWithKeys(int id);

        Enterprise GetWithKeys(int id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null);
        IQueryable<Enterprise> GetAll(bool readOnly = false);

        IQueryable<Enterprise> GetAll(string included = "", bool readOnly = false);
        Enterprise Insert(Enterprise entity);
        Enterprise Remove(Enterprise entity);

        Enterprise Remove(int id);
        IQueryable<Enterprise> Query(Expression<Func<Enterprise, bool>> predicate = null, bool readOnly = false, string included = "");
    }
}
