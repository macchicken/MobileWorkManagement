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
    //提案管理页面
    public class ProposalController : Controller
    {
        private readonly ICommandService commandService;
        private readonly IProjectDao projectDao;
        private readonly IProposalDao proposalDao;
        private readonly ISubprocessDao subprocessDao;
        public ProposalController(ICommandService commandService, IProjectDao projectDao, IProposalDao proposalDao,ISubprocessDao subprocessDao)
        {
            this.projectDao = projectDao;
            this.commandService = commandService;
            this.proposalDao = proposalDao;
            this.subprocessDao = subprocessDao;
        }

        //
        // GET: /Proposal/
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

        public PartialViewResult Proposalflow()
        {
            return PartialView();
        }
        public PartialViewResult RequirementCheck(string projectId,string typeCode)
        {
            var result = subprocessDao.Entities.Where<SubProcess>(m => (m.Id == projectId && m.TypeCode == typeCode)).AsNoTracking().SingleOrDefault();
            var model = new SubporecessModel();
            model.ProjectId = result.Id;
            model.State = result.State;
            model.Content = result.Content;
            model.Typecode = result.TypeCode;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult ProposalFlowInfo(string projectId)
        {
            Proposal proposal = proposalDao.Entities.Where(m => m.Id == projectId).AsNoTracking().SingleOrDefault();
            if (proposal!=null)
            {
                return Json(new { success = true, ProjectId = proposal.Id, State = proposal.State, ProposalOwner = proposal.ProposalOwner, ProposalStart = proposal.ProposalStart });
            }
            else
            {
                return Json(new { success = false });
            }
        }

       
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> UpdateProposalFlow(string projectId,int state,string proposalOwner,string next)
        {
            if (String.IsNullOrWhiteSpace(proposalOwner)) { return Json(new { success = false, mesg = "请指定一个提案负责人", ProjectId = projectId, State = state }); }
            if (state > 0)
            {
                state -= 1;
                var result = await commandService.Execute(new UpdateProposal(projectId, state, proposalOwner), CommandReturnType.EventHandled);
                if (result.Status == CommandStatus.Success)
                {
                    MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "提案流程到第" + (state + 1).ToString() + "步了\n" + next+"\n提案责任人: " + proposalOwner);
                    return Json(new { success = true, ProjectId = projectId, State = state, ProposalOwner = proposalOwner, Next = next });
                }
            }
            return Json(new { success = false });
        }

        // TODO 确认管制表的结构,完成实际生成管制表基本数据
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> FinishProposal(string projectId, int state,string proposalName,string proposalOwner, string marketing)
        {
            var result=await commandService.Execute(new UpdateProjectFlow(projectId,2),CommandReturnType.EventHandled);
            if (result.Status == CommandStatus.Success)
            {
                var result2 = await commandService.Execute(new UpdateProposal(projectId, state, proposalOwner), CommandReturnType.EventHandled);
                if (result2.Status == CommandStatus.Success)
                {
                    var result3 = await commandService.Execute(new CreateSubProcess(projectId, "R02", 0, ""),CommandReturnType.EventHandled);
                    if (result3.Status == CommandStatus.Success)
                    {
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "提案完成，客户确认完毕，请运营管理中心查看管制表，确认老师，制作项目合同");
                        MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "提案完成，客户确认完毕，请教研中心联系确认老师，课程需求沟通，确认课件时间");
                        return Json(new { success = true, ProjectId = projectId, ProposalName = proposalName, ProposalOwner = proposalOwner, Marketing = marketing });
                    }
                }
            }
            return Json(new { success = false, ProjectId = projectId, ProposalName = proposalName, ProposalOwner = proposalOwner, Marketing = marketing });
        }
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<ActionResult> UpdateRequireCheck(string projectId, int state,string proposalOwner,string next)
        {
            if (string.IsNullOrWhiteSpace(projectId)) { return Json(new { success = false }); }
            if (state > 0)
            {
                state -= 1;
                var result = await commandService.Execute(new UpdateSubProcess(projectId, "R01", state, next),CommandReturnType.EventHandled);
                if (result.Status == CommandStatus.Success)
                {
                    if (state == 4 && !String.IsNullOrWhiteSpace(proposalOwner))
                    {
                        var result2=await commandService.Execute(new CreateProposal(projectId, 0, proposalOwner, DateTime.Now), CommandReturnType.EventHandled);
                        if (result2.Status == CommandStatus.Success)
                        {
                            MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "提案制作流程开始了\n" + "提案责任人: " + proposalOwner+"\n可以召开项目会议了");
                            return Json(new { success = true, ProjectId = projectId, ProposalOwner = proposalOwner });
                        }
                        else
                        {
                            return Json(new { success = false, ProjectId = projectId, ProposalOwner = proposalOwner });
                        }
                    }
                    MailMessageHelper.CreateMessage("barry@qhfinance.org", "项目流程信使,项目编号" + projectId, "提案审核流程到第" + (state + 1).ToString() + "步了,请" + next);
                    return Json(new { success = true, ProjectId = projectId,Next=next });
                }

            }
            return Json(new { success = false });
        }
	}
}