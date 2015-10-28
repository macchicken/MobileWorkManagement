using Int.PM.ReadModel.Trains;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Classes
{
    public class Class : AggregateRoot
    {
        public Train Train { get; set; }
        [Required]
        [StringLength(50)]
        public string TrainId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Hour { get; set; }

        [StringLength(50)]
        public string Price { get; set; }
    }
}