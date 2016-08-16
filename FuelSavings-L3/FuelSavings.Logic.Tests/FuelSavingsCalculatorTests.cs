using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FuelSavings.Logic.FuelSavingsCalculator;

namespace FuelSavings.Logic.Tests
{
    [TestClass]
    public class FuelSavingsCalculatorTests
    {
        [TestMethod]
        public void CalculateSavingsPerMonth_ReturnsExpectedValues()
        {
            // arrange
            var calculator = new FuelSavingsCalculator(120, FuelSavingsCalculatorTimeFrame.Week, 20, 29, 1.50m);

            // act
            var savings = calculator.CalculateSavingsPerMonth();

            //assert
            Assert.AreEqual(savings, 12.10);
        }
    }
}
