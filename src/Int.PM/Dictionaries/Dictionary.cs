using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Dictionaries
{
    [Serializable]
    public class Dictionary : AggregateRoot<string>
    {
        private string _name;
        private string _parentId;
        private int _type;

        public Dictionary(string id, string name, string parentId, int type)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("ID", id);
            Assert.IsNotNullOrWhiteSpace("名称", name);
            ApplyEvent(new DictionaryCreated(id, name, parentId, type));
        }

        public void Update(string name, string parentId, int type)
        {
            Assert.IsNotNullOrWhiteSpace("名称", name);
            ApplyEvent(new DictionaryUpdated(Id, name, parentId, type));
        }
        private void Handle(DictionaryCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _parentId = evnt.ParentId;
            _type = evnt.Type;
        }
        private void Handle(DictionaryUpdated evnt)
        {
            _name = evnt.Name;
            _parentId = evnt.ParentId;
            _type = evnt.Type;
        }
    }
}
