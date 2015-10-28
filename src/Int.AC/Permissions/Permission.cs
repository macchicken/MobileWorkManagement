using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Permissions
{
    [Serializable]
    public class Permission : AggregateRoot<string>
    {
        private string _code;
        private string _name;
        private string _moduleId;

        public Permission(string id, string code, string name, string moduleId)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("权限ID", id);
            Assert.IsNotNullOrWhiteSpace("权限名", name);
            ApplyEvent(new PermissionCreated(id, code, name, moduleId));
        }

        public void Update(string code, string name, string moduleId)
        {
            Assert.IsNotNullOrWhiteSpace("权限名", name);
            ApplyEvent(new PermissionUpdated(Id, code, name, moduleId));
        }

        private void Handle(PermissionCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _code = evnt.Code;
            _name = evnt.Name;
            _moduleId = evnt.ModuleId;
        }
        private void Handle(PermissionUpdated evnt)
        {
            _code = evnt.Code;
            _name = evnt.Name;
            _moduleId = evnt.ModuleId;
        }
    }
}
