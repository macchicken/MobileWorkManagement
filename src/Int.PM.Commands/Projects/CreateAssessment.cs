using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.Commands.Projects
{
    [Serializable]
    public class CreateAssessment : AggregateCommand<string>
    {
        public string Order { get; private set; }
        public string Time { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Score { get; private set; }

        public CreateAssessment(string id, string order, string time, string type, string name, int score)
            : base(id)
        {
            Order = order;
            Time = time;
            Type = type;
            Name = name;
            Score = score;
        }
    }
}
