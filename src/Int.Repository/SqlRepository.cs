using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    [Component]
    /// <summary>
    /// 使用手写sql的方法实现仓储的接口
    /// 此接口没有限制AggregateRoot,让使用更灵活，但一般不建议使用,因为它违背领域驱动设计概念
    /// </summary>
    public class SqlRepository : ISqlRepository
    {
        UnitOfWorkBase unitOfWork;
        public SqlRepository(UnitOfWorkBase unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            this.unitOfWork = unitOfWork;
            this.unitOfWork.Configuration.AutoDetectChangesEnabled = false;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public int Execute(string sql, params object[] parms)
        {
            return unitOfWork.ExecuteCommand(sql, parms);
        }

        public T Get<T>(string sql, params object[] parms)
        {
            return unitOfWork.ExecuteQuery<T>(sql, parms).FirstOrDefault();
        }

        public List<T> GetList<T>(string sql, params object[] parms)
        {
            return unitOfWork.ExecuteQuery<T>(sql, parms).ToList();
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
    }
}
