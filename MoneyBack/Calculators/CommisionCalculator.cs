using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Calculators
{
    public class CommisionCalculator
    {
        public static decimal Calculate(decimal price)
        {
            return Math.Max(1.9m,
                Math.Round(price * 0.0019m, 2));
        }
    }
}
