﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCatalog.Common.Interfaces
{
    public interface IStock
    {
        int Quantity { get; set; }

        decimal Price { get; set; }
    }
}
