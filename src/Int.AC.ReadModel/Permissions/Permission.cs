using Int.AC.ReadModel.Modules;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Permissions
{
    public class Permission : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public Module Module { get; set; }


        [Required]
        [StringLength(50)]
        public string ModuleId { get; set; }
    }
}
