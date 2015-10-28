﻿using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Menus
{
    [Serializable]
    public class MenuUpdated : DomainEvent<string>
    {
        public string Text { get; private set; }

        public int MenuType { get; private set; }

        public string NavigateUrl { get; private set; }

        public string MobileUrl { get; private set; }

        public string ParentId { get; private set; }

        public int Sort { get; private set; }

        public string PermissionId { get; private set; }

        public bool UseAble { get; private set; }

        public MenuUpdated(string id, string text, int menuType, string navigateUrl, string mobileUrl, string parentId, int sort, string permissionId, bool useAble)
            : base(id)
        {
            Text = text;
            MenuType = menuType;
            NavigateUrl = navigateUrl;
            MobileUrl = mobileUrl;
            ParentId = parentId;
            Sort = sort;
            PermissionId = permissionId;
            UseAble = useAble;
        }
    }
}