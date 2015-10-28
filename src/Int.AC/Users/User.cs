using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Users
{
    [Serializable]
    public class User : AggregateRoot<string>
    {
        private string _code;
        private string _password;
        private string _name;
        private string _nameEn;
        private string _email;
        private string _phone;
        private string _jobName;
        private string _leaderId;
        private bool _useAble;
        private string[] _roleIds;
        private string[] _departments;

        public User(string id, string code, string name, string nameEn,
            string email, string phone, string jobName, string leaderId, string[] departments = null)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("用户ID", id);
            Assert.IsNotNullOrWhiteSpace("用户编码", code);
            Assert.IsNotNullOrWhiteSpace("用户名", name);
            ApplyEvent(new UserCreated(id, code, name, nameEn, email, phone, jobName, leaderId, departments));
        }

        public void Update(string code, string name, string nameEn,
            string email, string phone, string jobName, string leaderId, bool useAble, string[] departments = null)
        {
            Assert.IsNotNullOrWhiteSpace("部门名", name);
            ApplyEvent(new UserUpdated(Id, code, name, nameEn, email, phone, jobName, leaderId, useAble, departments));
        }

        public void ChangePassword(string password)
        {
            Assert.IsNotNullOrWhiteSpace("密码不能为空", password);
            ApplyEvent(new PasswordChanged(Id, password));
        }

        public void ChangeRoles(string[] roleIds)
        {
            ApplyEvent(new UserChangedRoles(Id, roleIds));
        }

        private void Handle(UserCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _code = evnt.Code;
            _name = evnt.Name;
            _nameEn = evnt.NameEn;
            _email = evnt.Email;
            _phone = evnt.Phone;
            _jobName = evnt.JobName;
            _leaderId = evnt.LeaderId;
            _departments = evnt.Departments;
        }
        private void Handle(UserUpdated evnt)
        {
           _code = evnt.Code;
           _name = evnt.Name;
           _nameEn = evnt.NameEn;
           _email = evnt.Email;
           _phone = evnt.Phone;
           _jobName = evnt.JobName;
           _leaderId = evnt.LeaderId;
           _useAble = evnt.UseAble;
           _departments = evnt.Departments;
        }
        private void Handle(PasswordChanged evnt)
        {
            _password = evnt.Password;
        }
        private void Handle(UserChangedRoles evnt)
        {
            _roleIds = evnt.RoleIds;
        }
    }
}
