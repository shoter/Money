using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MoneyBack.Calculators;

namespace MoneyBackTests
{
    [TestClass]
    public class CommisionCalculatorTests
    {
        [TestMethod]
        public void RealLifeTests()
        {
            //price, commision
            List<Tuple<decimal, decimal>> realLifeSamples = new List<Tuple<decimal, decimal>>()
            {
                new Tuple<decimal, decimal>( 463.75m, 1.90m ),
                new Tuple<decimal, decimal>( 321.15m, 1.90m ),
                new Tuple<decimal, decimal>( 2_245.95m, 4.27m ),
                new Tuple<decimal, decimal>( 1_135.40m, 2.16m ),
                new Tuple<decimal, decimal>( 1_146.20m, 2.18m ),
                new Tuple<decimal, decimal>( 1_018.24m, 1.93m ),
                new Tuple<decimal, decimal>( 923.85m, 1.90m ),
            };

            foreach (var sample in realLifeSamples)
            {
                Assert.AreEqual(sample.Item2, CommisionCalculator.Calculate(sample.Item1));
            }
        }
    }
}

