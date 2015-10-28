using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Entities
{
    public enum WorkingTimePlan
    {
        时间无特殊要求 = 0,
        只安排周末 = 1,
        重点安排周末 = 2,
        只安排工作日 = 3,
        重点安排工作日 = 4
    }
}
