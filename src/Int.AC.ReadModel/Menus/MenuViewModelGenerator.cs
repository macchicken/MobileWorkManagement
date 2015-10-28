using ECommon.Components;
using ECommon.Dapper;
using ENode.Eventing;
using ENode.Infrastructure;
using Int.AC.Menus;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Menus
{
    [Component]
    public class MenuViewModelGenerator : BaseEventHandler,
        IEventHandler<MenuCreated>,
        IEventHandler<MenuUpdated>
    {
        public void Handle(IHandlingContext context, MenuCreated evnt)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    connection.Insert(
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Text = evnt.Text,
                        MenuType = evnt.MenuType,
                        NavigateUrl = evnt.NavigateUrl,
                        MobileUrl = evnt.MobileUrl,
                        ParentId = evnt.ParentId,
                        Sort = evnt.Sort,
                        PermissionId = evnt.PermissionId,
                        UseAble = 1,
                        IsDeleted = 0,
                        CreatedOn = evnt.Timestamp,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version,
                    }, "Menus");
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Handle(IHandlingContext context, MenuUpdated evnt)
        {
            TryUpdateRecord(connection =>
            {
                return connection.Update(
                    new
                    {
                        Text = evnt.Text,
                        MenuType = evnt.MenuType,
                        NavigateUrl = evnt.NavigateUrl,
                        MobileUrl = evnt.MobileUrl,
                        ParentId = evnt.ParentId,
                        Sort = evnt.Sort,
                        PermissionId = evnt.PermissionId,
                        UseAble = evnt.UseAble,
                        UpdatedOn = evnt.Timestamp,
                        Version = evnt.Version
                    },
                    new
                    {
                        Id = evnt.AggregateRootId,
                        Version = evnt.Version - 1
                    }, "Menus");
            });
        }
    }
}
