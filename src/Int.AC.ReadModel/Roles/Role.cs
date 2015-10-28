using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Users;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Roles
{
    public class Role : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int Sort { get; set; }

        public bool UseAble { get; set; }

        public List<User> Users { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
