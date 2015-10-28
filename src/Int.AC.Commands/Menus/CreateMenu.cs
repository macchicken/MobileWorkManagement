using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Menus
{
    [Serializable]
    public class CreateMenu : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Text { get; private set; }

        public int MenuType { get; private set; }

        public string NavigateUrl { get; private set; }

        public string MobileUrl { get; private set; }

        public string ParentId { get; private set; }

        public int Sort { get; private set; }

        public string PermissionId { get; private set; }

        public CreateMenu(string text, int menuType, string navigateUrl, string mobileUrl, int sort, string parentId = null, string permissionId = null)
        {
            AggregateRootId = ObjectId.GenerateNewStringId(); 
            Text = text;
            MenuType = menuType;
            NavigateUrl = navigateUrl;
            MobileUrl = mobileUrl;
            Sort = sort;
            if(!string.IsNullOrWhiteSpace(parentId))
                ParentId = parentId;
            if(!string.IsNullOrWhiteSpace(permissionId))
                PermissionId = permissionId;
        }
    }
}
