using ENode.Commanding;
using Int.PM.ReadModel.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandService _commandService;

        public HomeController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [NonAction]
        protected string GetRootUrl()
        {
            return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (Request.IsAjaxRequest())
                result = PartialView(model);
            else
                result = View(model);
            return result;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult Notice()
        {
            return PartialView();
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}