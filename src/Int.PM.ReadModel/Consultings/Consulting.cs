using Int.PM.ReadModel.Entities;
using Int.PM.ReadModel.Products;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Consultings
{
    public class Consulting : AggregateRoot
    {
        public Product Product { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string ContractNo { get; set; }

        [StringLength(200)]
        public string Customer { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
