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
    public class PreparationController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IProjectDao _projectDao;
        private readonly IAssessmentDao _assessDao;

        public PreparationController(ICommandService commandService, IProjectDao projectDao,IAssessmentDao assessDao)
        {
            _commandService = commandService;
            _projectDao = projectDao;
            _assessDao = assessDao;
        }
        //
        // GET: /Preparation/
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

        public PartialViewResult TeacherCourseArrange(string projectId)
        {
            var result=_assessDao.Entities.Where<Assesment>(m => m.Id == projectId).AsNoTracking().ToList();
            List<AssessmentListModel> models = new List<AssessmentListModel>();
            foreach (var assess in result)
            {
                var model = new AssessmentListModel();
                model.Order = assess.OrderCode;
                model.Time = assess.Time;
                model.Type = assess.Type;
                model.Name = assess.Name;
                model.Score = assess.Score;
                models.Add(model);
            }
            return PartialView(models);
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> AddArrange(string projectId,string time, string type, string name)
        {
            String order = ObjectId.GenerateNewStringId();
            var result = await _commandService.Execute(new CreateAssessment(projectId, order, time, type, name, 0),CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new {success=true,ProjectId=projectId, Order=order, Time=time, Type=type, Name=name});
            }
            else
            {
                return Json(new { success = false, ProjectId = projectId, Order = order, Time = time, Type = type, Name = name });
            }
        }
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ModifyArrange(string projectId, string order, string time, string type, string name)
        {
            var result = await _commandService.Execute(new UpdateAssessment(projectId, order, time, type, name, 0), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, ProjectId = projectId, Order = order, Time = time, Type = type, Name = name });
            }
            else
            {
                return Json(new { success = false, ProjectId = projectId, Order = order, Time = time, Type = type, Name = name });
            }
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> Finished(string projectId,string destEmail)
        {
            var result = await _commandService.Execute(new UpdateProjectFlow(projectId, 4), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "项目准备完成,可以开始执行啦！");
                return Json(new { success = true, ProjectId = projectId, State = 4, Next = "项目准备完成,可以开始执行啦！" });
            }
            else
            {
                return Json(new { success = true, ProjectId = projectId});
            }
        }
	}
}