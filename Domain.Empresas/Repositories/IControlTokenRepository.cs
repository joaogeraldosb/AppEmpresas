using Domain.Empresas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Empresas.Repositories
{
    public interface IControlTokenRepository
    {
        ControlToken LoadNavigation(ControlToken enterprise, Expression<Func<Enterprise, object>> expression);

        ControlToken LoadCollection(ControlToken enterprise, string collectionPropName);
        ControlToken GetWithKeys(long id);

        ControlToken GetWithKeys(long id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null);
        IQueryable<ControlToken> GetAll(bool readOnly = false);

        IQueryable<ControlToken> GetAll(string included = "", bool readOnly = false);
        ControlToken Insert(ControlToken entity);
        ControlToken Remove(ControlToken entity);

        ControlToken Remove(long id);
        IQueryable<ControlToken> Query(Expression<Func<ControlToken, bool>> predicate = null, bool readOnly = false, string included = "");

    }
}
