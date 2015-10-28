using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Int.MobileUI.Models
{
    public class ConsultProject : ProjectModels
    {
        public string Rname { get; set; }
        public string Area { get; set; }
        public string RTelephone { get; set; }
        public string REmail { get; set; }
        public string CusBank { get; set; }
        public string CusMainBranch { get; set; }
        public string CusSubBranch { get; set; }
        public string CusContact { get; set; }
        public string CusTelephone { get; set; }
        public string CusEmail { get; set; }
        public string ProjectRtype { get; set; }
        public string RequireDept { get; set; }
        public string Duration { get; set; }
        public string Relvant { get; set; }
    }
}