using Int.AC.ReadModel.Permissions;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Menus
{
    public class Menu : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public MenuType MenuType { get; set; }

        [StringLength(255)]
        public string NavigateUrl { get; set; }
        [StringLength(255)]
        public string MobileUrl { get; set; }

        [StringLength(50)]
        public string ParentId { get; set; }
        public Menu Parent { get; set; }

        public int Sort { get; set; }

        public bool UseAble { get; set; }

        public Permission Permission { get; set; }
        [StringLength(50)]
        public string PermissionId { get; set; }

        [NotMapped]
        public int TreeLevel { get; set; }

        public bool IsWebMenu
        {
            get
            {
                return MenuType.Web == (MenuType.Web & MenuType);
            }
        }
        public bool IsMobileMenu
        {
            get
            {
                return MenuType.Mobile == (MenuType.Mobile & MenuType);
            }
        }
    }
}
