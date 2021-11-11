using MoneyBack.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Currencies
{
    public static class CurrencyProvider
    {
        public static ICurrency ProvideCurrency(StockBroker broker)
        {
            switch(broker)
            {
                case StockBroker.Etoro:
                    return new DolarCurrency();
                case StockBroker.Santander:
                    return new PolishCurrency();
            }

            throw new Exception();
        }
        
    }
}
