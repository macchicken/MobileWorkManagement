using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    [Component]
    public class RepositoryReadOnly<TAggregateRoot> : IRepositoryReadOnly<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        UnitOfWorkBase unitOfWork;

        public RepositoryReadOnly(UnitOfWorkBase unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
            unitOfWork.Configuration.AutoDetectChangesEnabled = false;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public virtual IQueryable<TAggregateRoot> Entities
        {
            get { return GetSet().Where(m => !m.IsDeleted); }
        }

        public TAggregateRoot GetById(string id)
        {
            return GetSet().Where(m => (object)m.Id == (object)id && !m.IsDeleted).FirstOrDefault();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                    unitOfWork = null;
                }
            }
        }

        IDbSet<TAggregateRoot> GetSet()
        {
            return unitOfWork.Set<TAggregateRoot>();
        }
    }
}
