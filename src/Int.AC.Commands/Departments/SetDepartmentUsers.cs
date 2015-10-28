using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Departments
{
    [Serializable]
    public class SetDepartmentUsers : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string[] UserIds { get; private set; }

        public SetDepartmentUsers(string id, string[] userIds)
            : base(id) 
        {
            UserIds = userIds;
        }
    }
}
