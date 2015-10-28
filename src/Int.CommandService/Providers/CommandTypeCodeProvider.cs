using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure.Impl;
using Int.AC.Commands.Departments;
using Int.AC.Commands.Menus;
using Int.AC.Commands.Modules;
using Int.AC.Commands.Permissions;
using Int.AC.Commands.Roles;
using Int.AC.Commands.Services;
using Int.AC.Commands.Users;
using Int.PM.Commands.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.CommandService.Providers
{
    [Component]
    public class CommandTypeCodeProvider : DefaultTypeCodeProvider<ICommand>
    {
        public CommandTypeCodeProvider()
        {
            RegisterType<CreateDepartment>(100);
            RegisterType<UpdateDepartment>(101);
            RegisterType<SetDepartmentUsers>(102);
            RegisterType<CreateMenu>(110);
            RegisterType<UpdateMenu>(111);
            RegisterType<CreateModule>(120);
            RegisterType<UpdateModule>(121);
            RegisterType<CreatePermission>(130);
            RegisterType<UpdatePermission>(131);
            RegisterType<CreateRole>(140);
            RegisterType<UpdateRole>(141);
            RegisterType<SetRolePermissions>(142);
            RegisterType<CreateService>(150);
            RegisterType<UpdateService>(151);
            RegisterType<CreateUser>(160);
            RegisterType<UpdateUser>(161);
            RegisterType<ChangePassword>(162);
            RegisterType<SetUserRoles>(163);
            RegisterType<StartTrainingProject>(170);
            RegisterType<UpdateTrainingProject>(171);
            RegisterType<StartConsultProject>(172);
            RegisterType<UpdateConsultProject>(173);
            RegisterType<StartProjectFlow>(174);
            RegisterType<CreateProposal>(175);
            RegisterType<UpdateProposal>(176);
            RegisterType<CreateSubProcess>(177);
            RegisterType<UpdateSubProcess>(178);
            RegisterType<UpdateProjectFlow>(179);
            RegisterType<CreateControlData>(180);
            RegisterType<CreateAssessment>(181);
            RegisterType<UpdateAssessment>(182);
            RegisterType<UpdateControlTable>(183);
            RegisterType<ProjectNotification>(190);
        }
    }
}
