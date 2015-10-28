using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class CreateControlData : AggregateCommand<string>
    {
        public string Order { get; private set; }//item的序号
        public string Time { get; private set; }//item的日期
        public string Type { get; private set; }//item的类型
        public string Name { get; private set; }//item的名称
        public string Content { get; private set; }//内容
        public string Remark { get; private set; }//补充

        public CreateControlData(string id, string order,string time,string type,string name,string content,string remark)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Content = content;
            Remark = remark;
        }

        
    }
}
