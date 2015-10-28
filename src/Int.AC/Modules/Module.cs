using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Modules
{
    [Serializable]
    public class Module : AggregateRoot<string>
    {
        private string _serviceId;
        private string _code;
        private string _text;
        private string _parentId;
        private int _sort;
        private bool _useAble;

        public Module(string id, string serviceId, string code, string text, string parentId, int sort)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("模块ID", id);
            Assert.IsNotNullOrWhiteSpace("服务ID", serviceId);
            Assert.IsNotNullOrWhiteSpace("编码", code);
            Assert.IsNotNullOrWhiteSpace("模块名", text);
            ApplyEvent(new ModuleCreated(id, serviceId, code, text, parentId, sort));
        }

        public void Update(string code, string text, string parentId, int sort, bool useAble)
        {
            Assert.IsNotNullOrWhiteSpace("编码", code);
            Assert.IsNotNullOrWhiteSpace("权限名", text);
            ApplyEvent(new ModuleUpdated(Id, code, text, parentId, sort, useAble));
        }

        private void Handle(ModuleCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _serviceId = evnt.ServiceId;
            _code = evnt.Code;
            _text = evnt.Text;
            _parentId = evnt.ParentId;
            _sort = evnt.Sort;
        }
        private void Handle(ModuleUpdated evnt)
        {
            _code = evnt.Code;
            _text = evnt.Text;
            _parentId = evnt.ParentId;
            _sort = evnt.Sort;
            _useAble = evnt.UseAble;
        }
    }
}
