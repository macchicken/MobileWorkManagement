using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Courses
{
    [Serializable]
    public class CourseCreated : DomainEvent<string>
    {
        public string Name { get; set; }

        public string Describe { get; set; }

        public string Remark { get; set; }

        public string[] Products { get; set; }

        public string[] CourseCategories { get; set; }

        public string[] JobCategories { get; set; }

        public string[] Tags { get; set; }

        public CourseCreated(string id, string name, string describe, string remark,
            string[] products, string[] courseCategories, string[] jobCategories, string[] tags)
            : base(id)
        {
            Name = name;
            Describe = describe;
            Remark = remark;
            Products = products;
            CourseCategories = courseCategories;
            JobCategories = jobCategories;
            Tags = tags;
        }
    }
}
