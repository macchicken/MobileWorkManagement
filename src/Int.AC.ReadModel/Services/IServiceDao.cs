﻿using Int.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.AC.ReadModel.Services
{
    public partial interface IServiceDao : IRepositoryReadOnly<Service> { }
}