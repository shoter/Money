using System;

namespace MoneyBack.Calculators
{
    public class SantanderCommisionCalculator : ICommisionCalculator
    {
        public decimal Calculate(decimal price)
        {
            return Math.Max(1.9m,
                Math.Round(price * 0.0019m, 2));
        }
    }
}
