using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Int.PM.ReadModel.Users;
using Int.PM.ReadModel.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Int.PM.ReadModel.Projects
{
    //展示项目信息聚合根，以及相关连对象的聚合根，定于了每个字段的属性,长度,
    //项目详细信息分为主要和扩展，项目的对象分为培训和咨询
    public class Project : AggregateRoot
    {
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }//用户id
        [Required]
        public DateTime ProjectCTime { get; set; }//项目创建时间
        [Required]
        public int State { get; set; }//项目状态，在第几个流程
        [Required]
        [StringLength(100)]
        public string ProjectType { get; set; }//项目类型
        [StringLength(100)]
        public string ProposalOwner { get; set; }//提案负责人
        [StringLength(200)]
        public string ContractNo { get; set; }//合同编号,和生成管制表信息同时生成
        public ProjectMain ProjectMain { get; set; }//培训项目对象
        public ProjectExtend ProjectExtend { get; set; }//项目扩展信息
        public Consult Consult { get; set; }//咨询项目对象

    }

    public class ProjectMain : AggregateRoot
    {
        [StringLength(50)]
        public string TrainingTarget { get; set; }//培训对象

        public string NumOfPerson { get; set; }//培训人数

        [StringLength(50)]
        public string ReceivedTime { get; set; }//收到需求的时间

        public string Days { get; set; }//培训天数

        [StringLength(50)]
        public string ExpectTime { get; set; }//预计启动时间

        [StringLength(50)]
        public string CourseTitle { get; set; }//课程需求主题
    }

    public class ProjectExtend : AggregateRoot
    {
        [StringLength(100)]
        public string ProjectContact { get; set; }//项目接触对象

        public bool Decision { get; set; }//接触对像是否有决策权

        [StringLength(100)]
        public string ProjectOrigin { get; set; }//项目需求来源

        [StringLength(100)]
        public string Rival { get; set; }//是否有竞争对手

        [StringLength(100)]
        public string Bid { get; set; }//是否需要进行招标

        public int ProjectPossi { get; set; }//项目成交可能性评估

        [StringLength(100)]
        public string CusProBudget { get; set; }//客户是否有项目预算

        [StringLength(100)]
        public string ProjectEmergency { get; set; }//项目紧急程度

        [StringLength(100)]
        public string CourseSubject { get; set; }//课程培训目的

        [StringLength(100)]
        public string CourseDetail { get; set; }//需求详细描述

        [StringLength(100)]
        public string CourseOther { get; set; }//其他补充

    }

    public class Consult : AggregateRoot
    {
        [StringLength(100)]
        public string Rname { get; set; }//需求人姓名

        [StringLength(100)]
        public string Area { get; set; }//需求人所属区域

        [StringLength(100)]
        public string RTelephone { get; set; }//需求人联系电话

        [StringLength(100)]
        public string REmail { get; set; }//需求人公司邮箱

        [StringLength(100)]
        public string CusBank { get; set; }//客户的银行(或其他机构)

        [StringLength(100)]
        public string CusMainBranch { get; set; }//客户的分行

        [StringLength(100)]
        public string CusSubBranch { get; set; }//客户的支行

        [StringLength(100)]
        public string CusContact { get; set; }//客户的联系人

        [StringLength(100)]
        public string CusTelephone { get; set; }//客户的联系电话

        [StringLength(100)]
        public string CusEmail { get; set; }//客户的邮箱

        [StringLength(100)]
        public string ProjectRtype { get; set; }//项目需求类型

        [StringLength(100)]
        public string RequireDept { get; set; }//需求部门

        public string Duration { get; set; }//项目预计执行时长

        [StringLength(100)]
        public string Relvant { get; set; }//涉及部门和岗位

        [StringLength(100)]
        public string ReceivedTime { get; set; }//收到需求的时间

        [StringLength(100)]
        public string ExpectTime { get; set; }//预计启动时间

    }

    public class Proposal : AggregateRoot
    {
        [StringLength(100)]
        public string Name { get; set; }//提案名称
        [Required]
        public int State { get; set; }//提案流程的状态,到几步流程
        [Required]
        [StringLength(100)]
        public string ProposalOwner { get; set; }//提案负责人
        [Required]
        public DateTime ProposalStart { get; set; }//提案开始时间
    }

    public class ControlTable : AggregateRoot
    {   //其余的信息包括课程内容从课程库获取,这个对象是管制表基本信息
        [Key, Column(Order = 0)]
        [StringLength(50)]
        public string Id { get; set; }
        [Key, Column(Order = 1)]
        [StringLength(50)]
        public string OrderCode { get; set; }//item的序号
        [StringLength(100)]
        public string Time { get; set; }//item的日期
        [StringLength(100)]
        public string Type { get; set; }//item的类型
        [StringLength(200)]
        public string Name { get; set; }//item的名称
        [StringLength(500)]
        public string Content { get; set; }//内容
        [StringLength(500)]
        public string Remark { get; set; }//补充
    }

    public class SubProcess : AggregateRoot
    {
        [Key,Column(Order = 0)]
        [StringLength(50)]
        public string Id { get; set; }
        [Key,Column(Order = 1)]
        [StringLength(10)]
        public string TypeCode { get; set; }
        [Required]
        public int State { get; set; }
        [StringLength(200)]
        public string Content { get; set; }

    }

    public class Contract : AggregateRoot
    {
        [StringLength(100)]
        public string Contractno { get; set; }//合同号,合同完成后生成
        [StringLength(500)]
        public string Teacher { get; set; }//任课老师
        public DateTime CourseMatime { get; set; }//课件时间
    }

    public class Assesment : AggregateRoot
    {
        [Key, Column(Order = 0)]
        [StringLength(50)]
        public string Id { get; set; }
        [Key, Column(Order = 1)]
        [StringLength(50)]
        public string OrderCode { get; set; }
        [StringLength(100)]
        public string Time { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        public int Score { get; set; }

    }
}
