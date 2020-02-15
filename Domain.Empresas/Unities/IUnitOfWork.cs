using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Empresas.Unities
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Starts a new transaction with the context
        /// </summary>
        /// <returns></returns>
        IUnitOfWork Begin();

        /// <summary>
        /// Save changes made in context
        /// </summary>
        void Save();

        /// <summary>
        /// Rollback all states changes made in context
        /// </summary>
        void RollbackStates();

        /// <summary>
        /// Confirm the changes and save the context
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback the changes made in transaction
        /// </summary>
        void RollbackTransaction();
    }
}
