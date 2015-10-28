using ECommon.Components;
using ENode.Eventing;
using ENode.Infrastructure.Impl;
using Int.AC.Departments;
using Int.AC.Menus;
using Int.AC.Modules;
using Int.AC.Permissions;
using Int.AC.Roles;
using Int.AC.Services;
using Int.AC.Users;
using Int.PM.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.EventService.Providers
{
    [Component]
    public class EventTypeCodeProvider : DefaultTypeCodeProvider<IEvent>
    {
        public EventTypeCodeProvider()
        {
            RegisterType<DepartmentCreated>(100);
            RegisterType<DepartmentUpdated>(101);
            RegisterType<DepartmentChangedUsers>(102);
            RegisterType<MenuCreated>(110);
            RegisterType<MenuUpdated>(111);
            RegisterType<ModuleCreated>(120);
            RegisterType<ModuleUpdated>(121);
            RegisterType<PermissionCreated>(130);
            RegisterType<PermissionUpdated>(131);
            RegisterType<RoleCreated>(140);
            RegisterType<RoleUpdated>(141);
            RegisterType<RoleChangedPermissions>(142);
            RegisterType<ServiceCreated>(150);
            RegisterType<ServiceUpdated>(151);
            RegisterType<UserCreated>(160);
            RegisterType<UserUpdated>(161);
            RegisterType<PasswordChanged>(162);
            RegisterType<UserChangedRoles>(163);
            RegisterType<TrainingStartedEvent>(170);
            RegisterType<TrainingUpdatedEvent>(171);
            RegisterType<ConsultStartedEvent>(172);
            RegisterType<ConsultUpdatedEvent>(173);
            RegisterType<ProjectFLowEvent>(174);
            RegisterType<ProposalStartedEvent>(175);
            RegisterType<ProposalUpdatedEvent>(176);
            RegisterType<SubprocessStartedEvent>(177);
            RegisterType<SubprocessUpdatedEvent>(178);
            RegisterType<ProjectFlowUpdatedEvent>(179);
            RegisterType<ControlTableItemCreated>(180);
            RegisterType<AssessmentRecordCreated>(181);
            RegisterType<AssessmentRecordUpdated>(182);
            RegisterType<ControlTableItemUpdated>(183);
            RegisterType<NotificationEvents>(190);
        }
    }
}
