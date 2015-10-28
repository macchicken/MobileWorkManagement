using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
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
        public async Task<ActionResult> ModifyCustomer(string cuscode, string name, string gender, int age, string address, string phoneNo, string email)
        {
            if (String.IsNullOrWhiteSpace(email)) { email = "user@domain"; }
            if (String.IsNullOrWhiteSpace(cuscode)) { return Json(new { success = false, errMesg = "客户编号为空" }); }
            return Json(new { success = true, Cuscode = cuscode, Name = name, Gender = gender, Age = age, Address = address, PhoneNo = phoneNo, Email = email });
        }
	}
}