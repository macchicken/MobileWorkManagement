using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Permissions
{
    [Serializable]
    public class CreatePermission : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string ModuleId { get; private set; }

        public CreatePermission(string code, string name, string moduleId)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            Code = code;
            Name = name;
            ModuleId = moduleId;
        }
    }
}
