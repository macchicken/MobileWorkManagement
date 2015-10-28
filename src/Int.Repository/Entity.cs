using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    public class Entity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
    }
}
