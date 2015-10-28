using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Services
{
    public class Service : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int Sort { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }
    }
}
