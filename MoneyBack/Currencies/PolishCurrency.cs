using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Currencies
{
    public class PolishCurrency : ICurrency
    {
        public string Symbol => "PLN";

        public string FormatPrice(decimal price)
            => $"{price} PLN";
    }
}
