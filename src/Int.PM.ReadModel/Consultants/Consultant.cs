using Int.PM.ReadModel.Dictionaries;
using Int.PM.ReadModel.Entities;
using Int.PM.ReadModel.Products;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Consultants
{
    public class Consultant : AggregateRoot
    {
        public List<ConsultantCategory> ConsultantCategories { get; set; }
        public List<Tag> Tags { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(2000)]
        public string Describe { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(2000)]
        public string Remark { get; set; }

        public List<Product> Products { get; set; }
    }
}
