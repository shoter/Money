﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Currencies
{
    public interface ICurrency
    {
        string Symbol { get; }
        
    }
}