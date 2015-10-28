using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Entities
{
    [Flags]
    public enum TeamType
    {
        金融培训 = 1,
        金融咨询 = 2,
        金融认证 = 4,
        海外培训 = 8
    }
}
