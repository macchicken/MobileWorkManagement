using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Entities
{
    public class Area : Entity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
