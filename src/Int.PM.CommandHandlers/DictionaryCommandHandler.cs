using ENode.Commanding;
using Int.PM.Commands.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Int.PM.Dictionaries;
using ECommon.Components;

namespace Int.PM.CommandHandlers
{
    [Component]
    public class DictionaryCommandHandler : ICommandHandler<CreateDictionary>,
        ICommandHandler<UpdateDictionary>
    {
        public void Handle(ICommandContext context, CreateDictionary command)
        {
            context.Add(new Dictionary(
                 command.AggregateRootId,
                 command.Name,
                 command.ParentId,
                 command.Type));
        }
        public void Handle(ICommandContext context, UpdateDictionary command)
        {
            context.Get<Dictionary>(command.AggregateRootId).Update(
                command.Name,
                command.ParentId,
                command.Type);
        }
    }
}
