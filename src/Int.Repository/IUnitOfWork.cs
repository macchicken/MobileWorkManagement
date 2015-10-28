using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void CommitAndRefreshChanges();

        void Rollback();
    }
}
