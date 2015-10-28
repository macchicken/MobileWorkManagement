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
    public class AssessmentController : Controller
    {
        private readonly ICommandService commandService;
        private readonly IProjectDao projectDao;
        private readonly IAssessmentDao assessDao;
        public AssessmentController(ICommandService commandService, IProjectDao projectDao, IAssessmentDao assessDao)
        {
            this.projectDao = projectDao;
            this.commandService = commandService;
            this.assessDao = assessDao;
        }
        //
        // GET: /Assessment/
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TeacherCourseAssesment(string projectId)
        {
            var result = assessDao.Entities.Where<Assesment>(m => m.Id == projectId).AsNoTracking().ToList();
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

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ModifyAssessment(string projectId, string order, string time, string type, string name, int score)
        {
            var result = await commandService.Execute(new UpdateAssessment(projectId, order, time, type, name, score),CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, Projectid = projectId, Time=time,Type=type,Name=name,Score=score});
            }
            else
            {
                return Json(new { success = false, Projectid = projectId, Time = time, Type = type, Name = name, Score = score });
            }
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> Finished(string projectId,string destEmail)
        {
            var result = await commandService.Execute(new UpdateProjectFlow(projectId, 6), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "完成评分，项目完成啦！");
                return Json(new { success = true, ProjectId = projectId, State = 6, Next = "完成评分，项目完成啦！" });
            }
            else
            {
                return Json(new { success = true, ProjectId = projectId });
            }
        }
	}
}