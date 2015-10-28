using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENode.Commanding;
using Int.MobileUI.Services;
using System.Collections.Specialized;
using System.Collections;
using Int.MobileUI.Models;
using Int.MobileUI.Extensions;
using System.Threading.Tasks;
using Int.PM.Commands.Projects;
using Int.PM.ReadModel.Projects;

namespace Int.MobileUI.Controllers
{
    //发起需求页面
    public class DemandController : Controller
    {
        //
        // GET: /Demand/
        private readonly ICommandService _commandService;

        public DemandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Training(){
            return PartialView();
        }

        public PartialViewResult Consult()
        {
            return PartialView();
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> TrainingCreated(ProjectModels form)
        {
            var result = await _commandService.Execute(new StartProjectFlow("hc105", "T1", DateTime.Now), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                var result2 = await _commandService.Execute(new StartTrainingProject(result.AggregateRootId, form.TrainingTarget, form.NumOfPerson, form.ReceivedTime, form.Days, form.ExpectTime,
                form.CourseTitle, form.ProjectContact, form.Decision, form.ProjectOrigin, form.Rival, form.Bid,
                form.ProjectPossi, form.CusProBudget, form.ProjectEmergency, form.CourseSubject, form.CourseDetail, form.CourseOther), CommandReturnType.EventHandled);
                if (result2.Status == CommandStatus.Success)
                {
                    var result3 = await _commandService.Execute(new CreateSubProcess(result.AggregateRootId, "R01", 1, ""), CommandReturnType.EventHandled);
                    if (result3.Status == CommandStatus.Success)
                    {
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + result.AggregateRootId, "培训项目需求单已提交,请区域总监审核");
                        return Json(new { success = true, errorMsg = "创建培训项目成功", ProjectId = result.AggregateRootId });
                    }
                }
            }
            return Json(new { success = false, errorMsg = "创建培训项目失败" });
        }

        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> ConsultCreated(ConsultProject form)
        {
            var result = await _commandService.Execute(new StartProjectFlow("hc105", "T2", DateTime.Now), CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                var result2 = await _commandService.Execute(new StartConsultProject(result.AggregateRootId, form.Rname, form.Area, form.RTelephone, form.REmail, form.CusBank, form.CusMainBranch,
                form.CusSubBranch, form.CusContact, form.CusTelephone, form.CusEmail, form.ProjectRtype, form.RequireDept, form.Duration, form.Relvant, form.ReceivedTime,
                form.ExpectTime, form.ProjectContact, form.Decision, form.ProjectOrigin, form.Rival, form.Bid, form.ProjectPossi, form.CusProBudget, form.ProjectEmergency,
                form.CourseSubject, form.CourseDetail, form.CourseOther), CommandReturnType.EventHandled);
                if (result2.Status == CommandStatus.Success)
                {
                    var result3 = await _commandService.Execute(new CreateSubProcess(result.AggregateRootId, "R01", 1, ""), CommandReturnType.EventHandled);
                    if (result3.Status == CommandStatus.Success)
                    {
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + result.AggregateRootId, "咨询项目需求单已提交,请区域总监审核");
                        return Json(new { success = true, errorMsg = "创建咨询项目成功", ProjectId = result.AggregateRootId });
                    }
                }
            }
            return Json(new { success = false, errorMsg = "创建咨询项目失败" });
        }

	}
}