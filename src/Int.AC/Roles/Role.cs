using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Roles
{
    [Serializable]
    public class Role : AggregateRoot<string>
    {
        private string _name;
        private int _sort;
        private bool _useAble;
        private string[] _permissionIds;

        public Role(string id, string name, int sort)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("角色ID", id);
            Assert.IsNotNullOrWhiteSpace("角色名", name);
            ApplyEvent(new RoleCreated(id, name, sort));
        }

        public void Update(string name, int sort, bool useAble)
        {
            Assert.IsNotNullOrWhiteSpace("角色名", name);
            ApplyEvent(new RoleUpdated(Id, name, sort, useAble));
        }

        public void ChangePermissions(string[] permissionIds)
        {
            ApplyEvent(new RoleChangedPermissions(Id, permissionIds));
        }

        private void Handle(RoleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _sort = evnt.Sort;
        }
        private void Handle(RoleUpdated evnt)
        {
            _name = evnt.Name;
            _sort = evnt.Sort;
            _useAble = evnt.UseAble;
        }
        private void Handle(RoleChangedPermissions evnt)
        {
            _permissionIds = evnt.PermissionIds;
        }
    }
}
