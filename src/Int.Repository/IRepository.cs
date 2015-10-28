using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    public interface IRepository<TAggregateRoot> : IDisposable where TAggregateRoot : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        bool AutoDetectChangesEnabled { get; set; }

        IQueryable<TAggregateRoot> Entities { get; }

        void Add(TAggregateRoot item);

        void Add(IEnumerable<TAggregateRoot> items);

        void Modify(TAggregateRoot item);

        void Merge(TAggregateRoot original, TAggregateRoot current);

        void Remove(TAggregateRoot item);

        void Remove(IEnumerable<TAggregateRoot> items);

        void TrackItem(TAggregateRoot item);

        TAggregateRoot GetById(string id);
    }
}
