using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
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
        public async Task<ActionResult> AddTea(string name, int age, int price, string specialty, string sex,string phone)
        {
            return Json(new { success = true, Name = name, Age = age, Price = price, Specialty = specialty, Sex = sex,Phone=phone });
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ModifyTea(string tcode, string name, int age, int price, string specialty, string sex,string phone)
        {
            if (String.IsNullOrWhiteSpace(tcode)) { return Json(new { success = false ,errMesg="老师编号为空"}); }
            return Json(new { success = true, Tcode = tcode, Name = name, Age = age, Price = price, Specialty = specialty, Sex = sex, Phone = phone });
        }
	}
}