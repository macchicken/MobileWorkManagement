using ENode.Commanding;
using Int.MobileUI.Models;
using Int.MobileUI.Services;
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
    //项目跟踪页面
    public class ProjectController : Controller
    {
        private readonly ICommandService commandService;
        private readonly IProjectDao projectDao;

        public ProjectController(ICommandService commandService, IProjectDao projectDao)
        {
            this.projectDao = projectDao;
            this.commandService = commandService;
        }

        //
        // GET: /Project/
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

        public PartialViewResult TrainDetail()
        {
            return PartialView();
        }

        public PartialViewResult ConsultDetail()
        {
            return PartialView();
        }

        public PartialViewResult ProjectFlow()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult getTrainDetail(string projectid)
        {
            var main=projectDao.Entities.Include(m => m.ProjectMain).Where(m => m.Id == projectid).AsNoTracking().SingleOrDefault();
            var extend = projectDao.Entities.Include(m => m.ProjectExtend).Where(m => m.Id == projectid).AsNoTracking().SingleOrDefault();
            if (main != null && extend!=null)
            {
                return ToTrainJson(main.ProjectMain, extend.ProjectExtend);
            }
            else
            {
                return ToTrainJson(new ProjectMain(), new ProjectExtend());
            }
        }

        [HttpPost]
        public JsonResult getConsultDetail(string projectid)
        {
            var consult = projectDao.Entities.Include(m => m.Consult).Where(m => m.Id == projectid).AsNoTracking().SingleOrDefault();
            var extend = projectDao.Entities.Include(m => m.ProjectExtend).Where(m => m.Id == projectid).AsNoTracking().SingleOrDefault();
            if (consult!=null&&extend!=null)
            {
                return ToConsultJson(consult.Consult, extend.ProjectExtend);
            }
            else
            {
                return ToConsultJson(new Consult(),new ProjectExtend());
            }
        }

        private JsonResult ToTrainJson(ProjectMain pma, ProjectExtend pe)
        {
            return Json(new
            {
                success = true,
                TrainingTarget = pma.TrainingTarget,
                NumOfPerson = pma.NumOfPerson,
                ReceivedTime = pma.ReceivedTime,
                Days = pma.Days,
                ExpectTime = pma.ExpectTime,
                CourseTitle = pma.CourseTitle,
                ProjectContact = pe.ProjectContact,
                Decision = pe.Decision,
                ProjectOrigin = pe.ProjectOrigin,
                Rival = pe.Rival,
                Bid = pe.Bid,
                ProjectPossi = pe.ProjectPossi,
                CusProBudget = pe.CusProBudget,
                ProjectEmergency = pe.ProjectEmergency,
                CourseSubject = pe.CourseSubject,
                CourseDetail = pe.CourseDetail,
                CourseOther = pe.CourseOther
            });
        }

        private JsonResult ToConsultJson(Consult cinfo, ProjectExtend extendInfo)
        {
            return Json(new
            {
                success = true,
                Rname = cinfo.Rname,
                Area = cinfo.Area,
                RTelephone = cinfo.RTelephone,
                REmail = cinfo.REmail,
                CusBank = cinfo.CusBank,
                CusMainBranch = cinfo.CusMainBranch,
                CusSubBranch = cinfo.CusSubBranch,
                CusContact = cinfo.CusContact,
                CusTelephone = cinfo.CusTelephone,
                CusEmail = cinfo.CusEmail,
                ProjectRtype = cinfo.ProjectRtype,
                RequireDept = cinfo.RequireDept,
                Duration = cinfo.Duration,
                Relvant = cinfo.Relvant,
                ReceivedTime = cinfo.ReceivedTime,
                ExpectTime = cinfo.ExpectTime,
                ProjectContact = extendInfo.ProjectContact,
                Decision = extendInfo.Decision,
                ProjectOrigin = extendInfo.ProjectOrigin,
                Rival = extendInfo.Rival,
                Bid = extendInfo.Bid,
                ProjectPossi = extendInfo.ProjectPossi,
                CusProBudget = extendInfo.CusProBudget,
                ProjectEmergency = extendInfo.ProjectEmergency,
                CourseSubject = extendInfo.CourseSubject,
                CourseDetail = extendInfo.CourseDetail,
                CourseOther = extendInfo.CourseOther
            });
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> TrainingUpdated(ProjectModels form)
        {
            var result = await commandService.Execute(new UpdateTrainingProject(form.ProjectId, form.TrainingTarget, form.NumOfPerson, form.ReceivedTime, form.Days, form.ExpectTime,
                form.CourseTitle, form.ProjectContact, form.Decision, form.ProjectOrigin, form.Rival, form.Bid,
                form.ProjectPossi, form.CusProBudget, form.ProjectEmergency, form.CourseSubject, form.CourseDetail, form.CourseOther), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, errorMsg = "修改培训项目成功" });
            }
            else
            {
                return Json(new { success = false, errorMsg = "修改培训项目失败" });
            }
        }
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ConsultUpdated(ConsultProject form)
        {
            var result = await commandService.Execute(new UpdateConsultProject(form.ProjectId, form.Rname, form.Area, form.RTelephone, form.REmail, form.CusBank, form.CusMainBranch,
                form.CusSubBranch, form.CusContact, form.CusTelephone, form.CusEmail, form.ProjectRtype, form.RequireDept, form.Duration, form.Relvant, form.ReceivedTime,
                form.ExpectTime, form.ProjectContact, form.Decision, form.ProjectOrigin, form.Rival, form.Bid, form.ProjectPossi, form.CusProBudget, form.ProjectEmergency,
                form.CourseSubject, form.CourseDetail, form.CourseOther), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                return Json(new { success = true, errorMsg = "修改咨询项目成功" });
            }
            else
            {
                return Json(new { success = false, errorMsg = "修改咨询项目失败" });
            }
        }
	}
}