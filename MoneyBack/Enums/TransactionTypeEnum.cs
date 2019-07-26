using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Enums
{
    public enum TransactionTypeEnum
    {
        Buy = 1,
        Sell = 2
    }

    public static class TransactionTypeEnumExtensions
    {
        public static decimal GetPriceMultiplier(this TransactionTypeEnum transactionType)
        {
            switch (transactionType)
            {
                case TransactionTypeEnum.Buy:
                    return 1m;
                case TransactionTypeEnum.Sell:
                    return -1m;
            }

            throw new NotImplementedException();
        }
    }
}
