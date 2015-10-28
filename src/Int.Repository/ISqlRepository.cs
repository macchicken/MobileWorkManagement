using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    /// <summary>
    /// 使用手写sql的方法实现仓储的接口
    /// 此接口没有限制AggregateRoot,让使用更灵活，但一般不建议使用,因为它违背领域驱动设计概念
    /// </summary>
    public interface ISqlRepository : IDisposable
    {
        int Execute(string sql, params object[] parms);

        T Get<T>(string sql, params object[] parms);

        List<T> GetList<T>(string sql, params object[] parms);
    } 
}
