
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.AreaHeaders
{
    public class AreaHandler : AggregateRoot
    {
        public int AreaId { get; set; }
        public int AreaType { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }
    }
}
