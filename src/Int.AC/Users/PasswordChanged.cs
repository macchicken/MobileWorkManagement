using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.Users
{
    [Serializable]
    public class PasswordChanged : DomainEvent<string>
    {
        public string Password { get; private set; }

        public PasswordChanged(string id, string password)
            : base(id)
        {
            Password = password;
        }
    }
}
