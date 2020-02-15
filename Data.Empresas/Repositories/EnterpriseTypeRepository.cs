using Domain.Empresas.Entities;
using Domain.Empresas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Empresas.Repositories
{
    public class EnterpriseTypeRepository : IEnterpriseTypeRepository
    {
        private readonly IRepository<EnterpriseType> _baseRepository;

        public EnterpriseTypeRepository(IRepository<EnterpriseType> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<EnterpriseType> GetAll(bool readOnly = false)
        {
            return _baseRepository.GetAll(readOnly);
        }

        public IQueryable<EnterpriseType> GetAll(string included = "", bool readOnly = false)
        {
            return _baseRepository.GetAll(included, readOnly);
        }

        public EnterpriseType GetWithKeys(int id)
        {
            return _baseRepository.GetWithKeys(id);
        }

        public EnterpriseType GetWithKeys(int id, IEnumerable<string> navigations = null, IEnumerable<string> collections = null)
        {
            return _baseRepository.GetWithKeys(new[] { (object)id }, navigations, collections);
        }

        public EnterpriseType Insert(EnterpriseType entity)
        {
            return _baseRepository.Insert(entity);
        }

        public IEnumerable<EnterpriseType> InsertMany(IEnumerable<EnterpriseType> entities)
        {
            return _baseRepository.InsertMany(entities);
        }

        public IQueryable<EnterpriseType> Query(Expression<Func<EnterpriseType, bool>> predicate = null, bool readOnly = false, string included = "")
        {
            return _baseRepository.Query(predicate, readOnly, included);
        }

        public EnterpriseType Remove(EnterpriseType entity)
        {
            return _baseRepository.Remove(entity);
        }

        public EnterpriseType Remove(int id)
        {
            return _baseRepository.Remove(id);
        }

        public IEnumerable<EnterpriseType> RemoveMany(IEnumerable<EnterpriseType> entities)
        {
            return _baseRepository.RemoveMany(entities);
        }

        public IEnumerable<EnterpriseType> RemoveMany(IEnumerable<int> ids)
        {
            var enterprises = GetAll(false).Join(ids, e => e.Id, id => id, (e, id) => e);

            return _baseRepository.RemoveMany(enterprises);
        }
    }
}
