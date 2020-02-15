using Domain.Empresas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Empresas.Repositories
{
    public interface IEnterpriseTypeRepository
    {
        EnterpriseType GetWithKeys(int id);
        EnterpriseType GetWithKeys(int id, IEnumerable<string> navigations = null,
            IEnumerable<string> collections = null);
        IQueryable<EnterpriseType> GetAll(bool readOnly = false);

        IQueryable<EnterpriseType> GetAll(string included = "", bool readOnly = false);

        IQueryable<EnterpriseType> Query(Expression<Func<EnterpriseType, bool>> predicate = null, bool readOnly = false, string included = "");

        EnterpriseType Insert(EnterpriseType entity);
        IEnumerable<EnterpriseType> InsertMany(IEnumerable<EnterpriseType> entities);

        EnterpriseType Remove(EnterpriseType entity);

        EnterpriseType Remove(int id);
        IEnumerable<EnterpriseType> RemoveMany(IEnumerable<EnterpriseType> entities);

        IEnumerable<EnterpriseType> RemoveMany(IEnumerable<int> ids);


    }
}
