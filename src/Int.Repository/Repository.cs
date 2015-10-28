using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    [Component]
    public class Repository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        UnitOfWorkBase unitOfWork;

        public Repository(UnitOfWorkBase unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
            unitOfWork.Configuration.AutoDetectChangesEnabled = false;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public bool AutoDetectChangesEnabled
        {
            get
            {
                return unitOfWork.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                unitOfWork.Configuration.AutoDetectChangesEnabled = value;
            }
        }

        public virtual IQueryable<TAggregateRoot> Entities
        {
            get { return GetSet().Where(m => !m.IsDeleted); }
        }

        public virtual void Add(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                if (item.CreatedOn == null || item.CreatedOn == DateTime.MinValue)
                {
                    item.CreatedOn = DateTime.Now;
                    item.UpdatedOn = DateTime.Now;
                }
                item.IsDeleted = false;
                GetSet().Add(item); 
            }
        }

        public virtual void Add(IEnumerable<TAggregateRoot> items)
        {
            foreach (TAggregateRoot entity in items)
            {
                if (entity.CreatedOn == null || entity.CreatedOn == DateTime.MinValue)
                    entity.CreatedOn = DateTime.Now;
                entity.IsDeleted = false;
                Add(entity);
            }
        }

        public virtual void Modify(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                if (unitOfWork.Entry(item).State == EntityState.Detached)
                {
                    item.UpdatedOn = DateTime.Now;
                    unitOfWork.Set<TAggregateRoot>().Attach(item);
                }
                unitOfWork.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual void Merge(TAggregateRoot original, TAggregateRoot current)
        {
            if (current.CreatedOn == null || current.CreatedOn == DateTime.MinValue)
            {
                current.CreatedOn = original.CreatedOn;
                current.UpdatedOn = original.UpdatedOn;
            }
            unitOfWork.Entry<TAggregateRoot>(original).CurrentValues.SetValues(current);
        }

        public virtual void Remove(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                unitOfWork.Entry<TAggregateRoot>(item).State = EntityState.Unchanged;
                GetSet().Remove(item);
            }
        }

        public virtual void Remove(IEnumerable<TAggregateRoot> items)
        {
            foreach (TAggregateRoot entity in items)
            {
                Remove(entity);
            }
        }

        public virtual void TrackItem(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
                unitOfWork.Entry<TAggregateRoot>(item).State = System.Data.Entity.EntityState.Unchanged;
        }

        //public TAggregateRoot GetById(TType id)
        //{
        //    return GetSet().Where(m => (object)m.Id == (object)id && !m.IsDeleted).FirstOrDefault();
        //}

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

        public TAggregateRoot GetById(string id)
        {
            return GetSet().Where(m => m.Id == id).SingleOrDefault();
        }
    }
}
