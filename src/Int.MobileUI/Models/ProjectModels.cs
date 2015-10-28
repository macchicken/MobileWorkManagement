using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Int.MobileUI.Models
{
    public class ProjectModels
    {
        public string ProjectId { get; set; }
        public string TrainingTarget { get; set; }

        public string NumOfPerson { get; set; }

        public string ReceivedTime { get; set; }

        public string Days { get; set; }

        public string ExpectTime { get; set; }

        public string ProjectContact { get; set; }

        public bool Decision { get; set; }

        public string ProjectOrigin { get; set; }

        public string Rival { get; set; }

        public string Bid { get; set; }

        public int ProjectPossi { get; set; }

        public string CusProBudget { get; set; }

        public string ProjectEmergency { get; set; }

        public string CourseTitle { get; set; }

        public string CourseSubject { get; set; }

        public string CourseDetail { get; set; }

        public string CourseOther { get; set; }
    }

    public class ProjectListModel
    {
        public string ProjectOwner { get; set; }
        public string ProjectCreatedTime { get; set; }
        public string ProjectType { get; set; }
        public string ProjectId { get; set; }
        public int State { get; set; }
        public string ProposalOwner { get; set; }
    }

    public class SubporecessModel
    {
        public string ProjectId { get; set; }
        public int State { get; set; }
        public string Typecode { get; set; }
        public string Content { get; set; }
    }

    public class AssessmentListModel
    {
        public string Order { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class ControlDataListModel
    {
        public string Order { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }

    }
}