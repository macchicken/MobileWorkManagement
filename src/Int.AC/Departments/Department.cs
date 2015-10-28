using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Departments
{
    [Serializable]
    public class Department : AggregateRoot<string>
    {
        private string _name;
        private string _parentId;
        string[] _userIds;
        public Department(string id, string name, string parentId)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("部门ID", id);
            Assert.IsNotNullOrWhiteSpace("部门名", name);
            ApplyEvent(new DepartmentCreated(id, name, parentId));
        }

        public void Update(string name, string parentId)
        {
            Assert.IsNotNullOrWhiteSpace("部门名", name);
            ApplyEvent(new DepartmentUpdated(Id, name, parentId));
        }

        public void ChangeUsers(string[] userIds)
        {
            ApplyEvent(new DepartmentChangedUsers(Id, userIds));
        }

        private void Handle(DepartmentCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _parentId = evnt.ParentId;
        }
        private void Handle(DepartmentUpdated evnt)
        {
            _name = evnt.Name;
            _parentId = evnt.ParentId;
        }
        private void Handle(DepartmentChangedUsers evnt)
        {
            _userIds = evnt.UserIds;
        }
    }
}
