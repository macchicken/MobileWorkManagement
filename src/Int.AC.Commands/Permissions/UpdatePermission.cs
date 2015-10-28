﻿using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Permissions
{
    [Serializable]
    public class UpdatePermission : AggregateCommand<string>
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string ModuleId { get; private set; }

        public UpdatePermission(string id, string code, string name, string moduleId)
            : base(id) 
        {
            Code = code;
            Name = name;
            ModuleId = moduleId;
        }
    }
}
