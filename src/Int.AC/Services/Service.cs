using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Services
{
    [Serializable]
    public class Service : AggregateRoot<string>
    {
        private string _name;
        private int _sort;
        private string _url;

        public Service(string id, string name, int sort, string url)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("应用ID", id);
            Assert.IsNotNullOrWhiteSpace("应用名", name);
            ApplyEvent(new ServiceCreated(Id, name, sort, url));
        }

        public void Update(string name, int sort, string url)
        {
            Assert.IsNotNullOrWhiteSpace("应用名", name);
            ApplyEvent(new ServiceUpdated(Id, name, sort, url));
        }

        private void Handle(ServiceCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _sort = evnt.Sort;
            _url = evnt.Url;
        }
        private void Handle(ServiceUpdated evnt)
        {
            _name = evnt.Name;
            _sort = evnt.Sort;
            _url = evnt.Url;
        }
    } 
}
