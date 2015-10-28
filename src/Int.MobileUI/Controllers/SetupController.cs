using Int.PM.ReadModel.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class SetupController : Controller
    {
        private readonly IProjectDao _projectdao;
        public SetupController(IProjectDao projectdao)
        {
            _projectdao = projectdao;
        }
        //
        // GET: /Setup/
        public ActionResult Index()
        {
            _projectdao.Entities.AsNoTracking().ToList();
            return View();
        }
	}
}