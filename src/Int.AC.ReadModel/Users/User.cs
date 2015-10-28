using Int.AC.ReadModel.Departments;
using Int.AC.ReadModel.Roles;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Users
{
    public class User : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Code { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string NameEn { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string JobName { get; set; }

        public bool UseAble { get; set; }

        public User Leader { get; set; }

        [StringLength(50)]
        public string LeaderId { get; set; }

        public List<Role> Roles { get; set; }
        public List<Department> Departments { get; set; }
    }
}
