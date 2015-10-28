using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> AddCourse(string name, string begindate, string enddate, string location, string state)
        {
            if (String.IsNullOrWhiteSpace(state)) { state = "等待安排"; }
            return Json(new { success = true, Name = name, Begindate = begindate, Enddate = enddate, Location = location, State = state });
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ModifyCourse(string ccode, string name, string begindate, string enddate, string location, string state)
        {
            if (String.IsNullOrWhiteSpace(state)) { state = "等待安排"; }
            if (String.IsNullOrWhiteSpace(ccode)) { return Json(new { success = false, errMesg = "课程编号为空" }); }
            return Json(new { success = true, Ccode = ccode, Name = name, Begindate = begindate, Enddate = enddate, Location = location, State = state });
        }
	}
}