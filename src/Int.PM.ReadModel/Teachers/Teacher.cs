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

namespace Int.PM.ReadModel.Teachers
{
    public class Teacher : AggregateRoot
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [StringLength(10)]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄段
        /// </summary>
        [StringLength(50)]
        public string Age { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        [StringLength(10)]
        public string IsInOffice { get; set; }

        public DateTime? LeaveOfficeTime { get; set; }

        /// <summary>
        /// 年资
        /// </summary>
        [StringLength(20)]
        public string Seniority { get; set; }

        /// <summary>
        /// 工作时间计划
        /// </summary>
        public int WorkingTimePlan { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        [StringLength(200)]
        public string Province { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        [StringLength(200)]
        public string City { get; set; }


        [StringLength(200)]
        public string OfficePhone { get; set; }

        [StringLength(200)]
        public string PersonalCall { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string QQMsn { get; set; }

        [StringLength(200)]
        public string LinkMan { get; set; }

        [StringLength(200)]
        public string LinkPhone { get; set; }

        [StringLength(200)]
        public string LinkEmail { get; set; }

        /// <summary>
        /// 签约情况
        /// </summary>
        public int SigningType { get; set; }
        [StringLength(200)]
        public string ContractNo { get; set; }

        /// <summary>
        /// 工作经历
        /// </summary>
        public string WorkExperiences { get; set; }

        /// <summary>
        /// 授课/咨询经历
        /// </summary>
        public string TeachExperiences { get; set; }

        public List<Tag> Tags { get; set; }

        /// <summary>
        /// 教育经历
        /// </summary>
        [StringLength(5000)]
        public string EduExperience { get; set; }

        /// <summary>
        /// 专攻领域
        /// </summary>
        public List<Territory> Territories { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        [StringLength(2000)]
        public string Specialty { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        public List<Industry> Industries { get; set; }

        /// <summary>
        /// 推介人
        /// </summary>
        [StringLength(200)]
        public string PromoteMan { get; set; }
        [StringLength(200)]
        public string PromotePhone { get; set; }

        /// <summary>
        /// 价钱
        /// </summary>
        public int Price { get; set; }

        [StringLength(5000)]
        public string Remark { get; set; }

        public int TeamType { get; set; }

        public List<Product> Products { get; set; }
    }
}
