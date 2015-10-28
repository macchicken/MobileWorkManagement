using Int.AC.ReadModel.Services;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Modules
{
    public class Module : AggregateRoot
    {
        public Service Service { get; set; }
        [Required]
        [StringLength(50)]
        public string ServiceId { get; set; }

        [Required]
        [StringLength(200)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [StringLength(50)]
        public string ParentId { get; set; }
        public Module Parent { get; set; }

        public int Sort { get; set; }

        public bool UseAble { get; set; }

        [NotMapped]
        public int TreeLevel { get; set; }
    }
}
