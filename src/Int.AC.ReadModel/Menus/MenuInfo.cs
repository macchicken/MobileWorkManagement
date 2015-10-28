using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Menus
{
    public class MenuInfo
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public int MenuType { get; set; }
        public string NavigateUrl { get; set; }
        public string MobileUrl { get; set; }
        public string ParentId { get; set; }
        public int Sort { get; set; }
        public bool UseAble { get; set; }
        public string PermissionId { get; set; }
        public string ServiceUrl { get; set; }
        public int TreeLevel { get; set; }
    }
}
