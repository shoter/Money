using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Calculators
{
    public class ProfitBackCalculator
    {
        public static decimal Calculate(int holdedAmount, decimal profit)
        {
            profit = -profit;

            if(profit + 1.9m > 1000m)
            {
                return profit / (holdedAmount * 1.0019m);
            }
            else
            {
                return (profit + 1.9m) / holdedAmount;
            }
        }
    }
}
