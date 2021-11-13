using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Currencies
{
    public class DolarCurrency : ICurrency
    {
        public string Symbol => "$";

        public string FormatPrice(decimal? price)
            => price != null ? $"{price:0.###} $" : "";
    }
}
