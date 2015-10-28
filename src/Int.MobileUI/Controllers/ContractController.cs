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
    //合同信息管理页面
    public class ContractController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IProjectDao _projectDao;
        private readonly ISubprocessDao _subprocessDao;
        private readonly IControlTableDao _controlDao;

        public ContractController(ICommandService commandService, IProjectDao projectDao, ISubprocessDao subprocessDao,IControlTableDao controlDao)
        {
            _projectDao = projectDao;
            _commandService = commandService;
            _subprocessDao = subprocessDao;
            _controlDao = controlDao;
        }
        //
        // GET: /Contract/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var result = _projectDao.Entities.Where<Project>(m => m.UserId == "hc105").AsNoTracking().ToList();
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

        public PartialViewResult ContractDetail()
        {
            return PartialView();
        }

        public PartialViewResult ControlTable(string projectId)
        {
            var result = _controlDao.Entities.Where<ControlTable>(m => m.Id == projectId).AsNoTracking().ToList();
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

        public PartialViewResult ContractInfo()
        {
            return PartialView();
        }
        public PartialViewResult CourseDiscuss(string projectId, string typeCode)
        {
            var result = _subprocessDao.Entities.Where<SubProcess>(m => (m.Id == projectId && m.TypeCode == typeCode)).AsNoTracking().SingleOrDefault();
            var model = new SubporecessModel();
            model.ProjectId = result.Id;
            model.State = result.State;
            model.Content = result.Content;
            model.Typecode = result.TypeCode;
            return PartialView(model);
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> UpdateCourseDiscuss(string projectId, int state, string next, Boolean finish)
        {
            if (string.IsNullOrWhiteSpace(projectId)) { return Json(new { success = false }); }
            if (state > 0)
            {
                state -= 1;
                var result = await _commandService.Execute(new UpdateSubProcess(projectId, "R02", state, next), CommandReturnType.EventHandled);
                if (result.Status == CommandStatus.Success)
                {
                    if (finish) {
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, next);
                        return Json(new { success = true, ProjectId = projectId, Next = next });
                    }
                    else
                    {
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "需求沟通流程到第" + (state + 1).ToString() + "步了,请" + next);
                        return Json(new { success = true, ProjectId = projectId, Next = next });
                    }
                }
            }
            return Json(new { success = false, ProjectId = projectId, Next = next });
        }

        [HttpPost]
        public JsonResult MarketNotified(string projectId, string next, string destmail)
        {
            MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, next);
            return Json(new { success = true, ProjectId = projectId, Next = next });
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> OperationNotified(string projectId, string next, string destmail)
        {
            var result = await _commandService.Execute(new UpdateProjectFlow(projectId, 3), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, next);
                return Json(new { success = true, ProjectId = projectId, State=3,Next = next });
            }
            else
            {
                return Json(new { success = false, ProjectId = projectId, Next = next });
            }
        }
	}
}