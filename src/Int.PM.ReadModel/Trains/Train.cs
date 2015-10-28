using Int.PM.ReadModel.Entities;
using Int.PM.ReadModel.Products;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Trains
{
    public class Train : AggregateRoot
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

        /// <summary>
        /// 培训天数
        /// </summary>
        [StringLength(200)]
        public string Days { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 培训地点
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 负责人员
        /// </summary>
        [StringLength(200)]
        public string Handler { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
