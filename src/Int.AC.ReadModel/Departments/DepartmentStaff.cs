using ENode.Domain;
using Int.AC.ReadModel.Users;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Departments
{
    public class DepartmentStaff : Entity
    {
        public Department Department { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentId { get; set; }

        public User User { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        public StaffType StaffType { get; set; }
    }
}
