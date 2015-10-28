using Int.AC.ReadModel.Users;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Departments
{
    public class Department : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ParentId { get; set; }
        public Department Parent { get; set; }

        public List<User> Users { get; set; }

        [NotMapped]
        public int TreeLevel { get; set; }
    }
}
