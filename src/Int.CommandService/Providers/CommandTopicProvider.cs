using ECommon.Components;
using ENode.Commanding;
using ENode.EQueue;
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
    public class CommandTopicProvider : AbstractTopicProvider<ICommand>
    {
        public CommandTopicProvider()
        {
            RegisterTopic("DepartmentCommandTopic", typeof(CreateDepartment), typeof(UpdateDepartment), typeof(SetDepartmentUsers));
            RegisterTopic("MenuCommandTopic", typeof(CreateMenu), typeof(UpdateMenu));
            RegisterTopic("ModuleCommandTopic", typeof(CreateModule), typeof(UpdateModule));
            RegisterTopic("PermissionCommandTopic", typeof(CreatePermission), typeof(UpdatePermission));
            RegisterTopic("RoleCommandTopic", typeof(CreateRole), typeof(UpdateRole), typeof(SetRolePermissions));
            RegisterTopic("ServiceCommandTopic", typeof(CreateService), typeof(UpdateService));
            RegisterTopic("UserCommandTopic", typeof(CreateUser), typeof(UpdateUser), typeof(ChangePassword), typeof(SetUserRoles));
            RegisterTopic("ProjectCommandTopic", typeof(StartTrainingProject), typeof(UpdateTrainingProject), typeof(StartConsultProject), typeof(UpdateConsultProject),
                typeof(StartProjectFlow),typeof(UpdateProjectFlow),typeof(CreateProposal),typeof(UpdateProposal),typeof(CreateSubProcess),typeof(UpdateSubProcess),
                typeof(CreateControlData),typeof(UpdateControlTable),typeof(CreateAssessment),typeof(UpdateAssessment));
            RegisterTopic("NotificationCommandTopic", typeof(ProjectNotification));
        }
    }
}