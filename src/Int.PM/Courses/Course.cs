using ENode.Domain;
using Int.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Courses
{
    [Serializable]
    public class Course : AggregateRoot<string>
    {
        private string _name;
        private string _describe;
        private string _remark;
        private string[] _courseCategories;
        private string[] _jobCategories;
        private string[] _tags;
        private string[] _products;

        public Course(string id, string name, string describe, string remark,
            string[] products, string[] courseCategories, string[] jobCategories, string[] tags)
            : base(id)
        {
            Assert.IsNotNullOrWhiteSpace("课程ID", id);
            ApplyEvent(new CourseCreated(id, name, describe, remark, products, courseCategories, jobCategories,tags));
        }

        public void Update(string name, string describe, string remark,
            string[] products, string[] courseCategories, string[] jobCategories, string[] tags)
        {
            ApplyEvent(new CourseUpdated(Id, name, describe, remark, products, courseCategories, jobCategories, tags));
        }

        private void Handle(CourseCreated evnt)
        {
            _id = evnt.AggregateRootId;
            _name = evnt.Name;
            _describe = evnt.Describe;
            _remark = evnt.Remark;
            _courseCategories = evnt.CourseCategories;
            _jobCategories = evnt.JobCategories;
            _tags = evnt.Tags;
            _products = evnt.Products;
        }
        private void Handle(CourseUpdated evnt)
        {
            _name = evnt.Name;
            _describe = evnt.Describe;
            _remark = evnt.Remark;
            _courseCategories = evnt.CourseCategories;
            _jobCategories = evnt.JobCategories;
            _tags = evnt.Tags;
            _products = evnt.Products;
        }
    }
}
