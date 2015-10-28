using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Int.MobileUI.Models
{
    public class TeacherListModel
    {
        public int tcode { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string major { get; set; }
        public string status { get; set; }
        public int amountOfCourse { get; set; }
    }

    public class CourseListModel
    {
        public int ccode { get; set; }
        public string name { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string location { get; set; }
        public string state { get; set; }
    }

    public class CustomerListModel
    {
        public string cuscode { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }

    }
}