using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Dictionaries
{
    public class JobCategory : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public JobCategory Parent { get; set; }
        [StringLength(50)]
        public string ParentId { get; set; }
    }
}
