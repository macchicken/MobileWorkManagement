﻿using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Modules
{
    [Serializable]
    public class CreateModule : AggregateCommand<string>, ICreatingAggregateCommand
    {
        public string ServiceId { get; private set; }

        public string Code { get; private set; }

        public string Text { get; private set; }

        public string ParentId { get; private set; }

        public int Sort { get; private set; }

        public CreateModule(string serviceId, string code, string text, int sort, string parentId = null)
        {
            AggregateRootId = ObjectId.GenerateNewStringId();
            ServiceId = serviceId;
            Code = code;
            Text = text;
            Sort = sort;
            if (!string.IsNullOrWhiteSpace(parentId))
                ParentId = parentId;
        }
    }
}
