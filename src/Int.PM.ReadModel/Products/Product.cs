using Int.PM.ReadModel.Consultants;
using Int.PM.ReadModel.Courses;
using Int.PM.ReadModel.Files;
using Int.PM.ReadModel.Teachers;
using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Products
{
    public class Product : AggregateRoot
    {
        public Teacher Teacher { get; set; }
        [Required]
        [StringLength(50)]
        public string TeacherId { get; set; }
        public Course Course { get; set; }
        [StringLength(50)]
        public string CourseId { get; set; }
        public Consultant Consultant { get; set; }
        [StringLength(50)]
        public int ConsultantId { get; set; }

        /// <summary>
        /// 课时
        /// </summary>
        public int Period { get; set; }

        public int Price { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        public List<File> Files { get; set; }
    }
}
