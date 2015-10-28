using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Commands.Users
{
    [Serializable]
    public class ChangePassword : AggregateCommand<string>
    {
        public string Password { get; private set; }

        public ChangePassword(string id, string password)
            : base(id) 
        {
            Password = password;
        }
    }
}
