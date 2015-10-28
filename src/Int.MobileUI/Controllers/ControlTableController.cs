using ECommon.Utilities;
using ENode.Commanding;
using Int.MobileUI.Models;
using Int.PM.Commands.Projects;
using Int.PM.ReadModel.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Int.MobileUI.Controllers
{
    public class ControlTableController : Controller
    {
        private readonly ICommandService commandService;
        private readonly IProjectDao projectDao;
        private readonly IControlTableDao controlDao;
        public ControlTableController(ICommandService commandService, IProjectDao projectDao, IControlTableDao controlDao)
        {
            this.commandService = commandService;
            this.projectDao = projectDao;
            this.controlDao = controlDao;
        }
        //
        // GET: /ControlTable/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var result = projectDao.Entities.Where<Project>(m => m.UserId == "hc105").AsNoTracking().ToList();
            List<ProjectListModel> models = new List<ProjectListModel>();
            foreach (var project in result)
            {
                var model = new ProjectListModel();
                model.ProjectOwner = project.UserId;
                model.ProjectId = project.Id;
                model.ProjectCreatedTime = project.ProjectCTime.ToString();
                model.ProjectType = project.ProjectType;
                model.State = project.State;
                model.ProposalOwner = project.ProposalOwner;
                models.Add(model);
            }
            return View(models);
        }

        public PartialViewResult ControlItems(string projectId)
        {
            var result = controlDao.Entities.Where<ControlTable>(m => m.Id == projectId).AsNoTracking().ToList();
            List<ControlDataListModel> models = new List<ControlDataListModel>();
            foreach (var item in result)
            {
                var model = new ControlDataListModel();
                model.Order = item.OrderCode;
                model.Time = item.Time;
                model.Type = item.Type;
                model.Name = item.Name;
                model.Content = item.Content;
                model.Remark = item.Remark;
                models.Add(model);
            }
            return PartialView(models);
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> AddItem(string projectId,string time,string type,string name,string content,string remark)
        {
            String order = ObjectId.GenerateNewStringId();
            var result = await commandService.Execute(new CreateControlData(projectId, order, time, type, name, content, remark),CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, Order = order });
            }
            else
            {
                return Json(new { success = false, ProjectId=projectId });
            }
        }
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ModifyItem(string projectId, string order, string time, string type, string name, string content, string remark)
        {
            var result = await commandService.Execute(new UpdateControlTable(projectId, order, time, type, name, content, remark), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, Order = order });
            }
            else
            {
                return Json(new { success = false, ProjectId = projectId });
            }
        }

	}
}