using Domain.Empresas.Unities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32.SafeHandles;
using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Util;

namespace Data.Empresas.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IDbContextTransaction _contextTransaction;

        protected bool Disposed { get; private set; } = false;
        protected SafeHandle Handle { get; } = new SafeFileHandle(IntPtr.Zero, true);

        /// <summary>
        /// Construtor of UnitOfWork to inject context.
        /// </summary>
        /// <param name="context"/>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IUnitOfWork Begin()
        {
            _contextTransaction = _context.Database.BeginTransaction();
            return this;
        }

        /// <summary>
        /// Try commit all changes in transaction and realize Rollback if fail
        /// </summary>
        public void Commit()
        {
            try
            {
                Save();

                if (_contextTransaction != null)
                    _contextTransaction.GetDbTransaction().Commit();
            }
            catch (Exception dbex)
            {
                RollbackTransaction();
                throw new ApiException(HttpStatusCode.Conflict, "Conflict", dbex); 
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;
            
            if(disposing)
            {
                Handle.Dispose();
                _contextTransaction?.Dispose();
                _context.Dispose();

                _contextTransaction = null;
                Disposed = true;
            }
        }

        public void RollbackStates()
        {
            _context.ChangeTracker
                .Entries()
                .Where(e => e.State != EntityState.Added)
                .ToList()
                .ForEach(x => x.Reload());
        }

        public void RollbackTransaction()
        {
            try
            {
                RollbackStates();

                if (_contextTransaction != null)
                    _contextTransaction.GetDbTransaction().Rollback();
            }
            finally
            {
                Dispose();
            }
        }

        public void Save()
        {
            try 
            { 
                _context.SaveChanges(); 
            }
            catch (Exception dbex)
            {
                RollbackStates();
                throw new ApiException(HttpStatusCode.Conflict, "Conflict", dbex);
            }
        }
    }
}
