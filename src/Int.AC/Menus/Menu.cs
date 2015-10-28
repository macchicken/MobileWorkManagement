using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Menus
{
    [Serializable]
    public class Menu : AggregateRoot<string>
    {
        private string _text;
        private int _menuType;
        private string _navigateUrl;
        private string _mobileUrl;
        private string _parentId;
        private int _sort;
        private string _permissionId;
        private bool _useAble;

        public Menu(string id, string text, int menuType, string navigateUrl, string mobileUrl, string parentId, int sort, string permissionId)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("按钮ID", id);
            Assert.IsNotNullOrWhiteSpace("按钮名", text);
            ApplyEvent(new MenuCreated(id, text, menuType, navigateUrl, mobileUrl, parentId, sort, permissionId));
        }

        public void Update(string text, int menuType, string navigateUrl, string mobileUrl, string parentId, int sort, string permissionId, bool useAble)
        {
            Assert.IsNotNullOrWhiteSpace("按钮名", text);
            ApplyEvent(new MenuUpdated(Id, text, menuType, navigateUrl, mobileUrl, parentId, sort, permissionId, useAble));
        }

        private void Handle(MenuCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _text = evnt.Text;
            _menuType = evnt.MenuType;
            _navigateUrl = evnt.NavigateUrl;
            _mobileUrl = evnt.MobileUrl;
            _parentId = evnt.ParentId;
            _sort = evnt.Sort;
            _permissionId = evnt.PermissionId;
        }
        private void Handle(MenuUpdated evnt)
        {
            _text = evnt.Text;
            _menuType = evnt.MenuType;
            _navigateUrl = evnt.NavigateUrl;
            _mobileUrl = evnt.MobileUrl;
            _parentId = evnt.ParentId;
            _sort = evnt.Sort;
            _permissionId = evnt.PermissionId;
            _useAble = evnt.UseAble;
        }
    }
}
