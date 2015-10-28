using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Entities
{
    public class Payment : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DeadLine { get; set; }
        public string Remark { get; set; }
    }
}
