using MoneyBack.Enums;

using System;

namespace MoneyBack.Calculators
{
    public static class CalculatorProvider
    {
        public static ICommisionCalculator Provide(StockBroker broker)
        {
            switch (broker)
            {
                case StockBroker.Santander:
                    return new SantanderCommisionCalculator();
                case StockBroker.Etoro:
                    return new EtoroCommissionCalculator();
                default:
                    throw new Exception();
            }
        }
    }
}