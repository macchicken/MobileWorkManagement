﻿using ECommon.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    [Component]
    public class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        public UnitOfWorkBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    string msg = string.Empty;
                    switch (sqlEx.Number)
                    {
                        case 2:
                            msg = "连接数据库超时，请检查网络连接或者数据库服务器是否正常。";
                            break;
                        case 17:
                            msg = "SqlServer服务不存在或拒绝访问。";
                            break;
                        case 17142:
                            msg = "SqlServer服务已暂停，不能提供数据服务。";
                            break;
                        case 2812:
                            msg = "指定存储过程不存在。";
                            break;
                        case 208:
                            msg = "指定名称的表不存在。";
                            break;
                        case 4060: //数据库无效。
                            msg = "所连接的数据库无效。";
                            break;
                        case 18456: //登录失败
                            msg = "使用设定的用户名与密码登录数据库失败。";
                            break;
                        case 547:
                            msg = "外键约束，无法保存数据的变更。";
                            break;
                        case 2627:
                            msg = "主键重复，无法插入数据。";
                            break;
                        case 2601:
                            msg = "未知错误。";
                            break;
                    }
                    throw new RepositoryException(msg);
                }
                throw;
            }
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);
        }

        public void Rollback()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.Entity.EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
    }
}