using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.CRM.ReadModel.Files
{
    public class File : AggregateRoot
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [StringLength(255)]
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int Size { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatorId { get; set; }
    }
}

