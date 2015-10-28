using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Entities
{
    public class City : Entity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
