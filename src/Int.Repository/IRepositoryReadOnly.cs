using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    public interface IRepositoryReadOnly<TAggregateRoot> : IDisposable where TAggregateRoot : AggregateRoot
    {
        IQueryable<TAggregateRoot> Entities { get; }

        TAggregateRoot GetById(string id);
    }
}
