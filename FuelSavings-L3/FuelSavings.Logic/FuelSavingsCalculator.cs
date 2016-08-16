using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSavings.Logic
{
    public class FuelSavingsCalculator
    {
        public readonly int milesDriven;
        public readonly FuelSavingsCalculatorTimeFrame timeframe;
        public readonly int tradeMpg;
        public readonly int newMpg;
        public readonly decimal ppg;

        public FuelSavingsCalculator(int milesDriven, FuelSavingsCalculatorTimeFrame timeframe, int tradeMpg, int newMpg, decimal ppg)
        {
            this.milesDriven = milesDriven;
            this.timeframe = timeframe;
            this.tradeMpg = tradeMpg;
            this.newMpg = newMpg;
            this.ppg = ppg;
        }

        public decimal CalculateSavingsPerMonth()
        {
            var milesDrivenPerMonth = CalculateMilesDrivenPerMonth(milesDriven, timeframe);
            var tradeFuelCostPerMonth = CalculateMonthlyCost(milesDrivenPerMonth, ppg, tradeMpg);
            var newFuelCostPerMonth = CalculateMonthlyCost(milesDrivenPerMonth, ppg, newMpg);
            var savingsPerMonth = tradeFuelCostPerMonth - newFuelCostPerMonth;

            return Math.Round(savingsPerMonth, 2);
        }

        private decimal CalculateMilesDrivenPerMonth(int milesDriven, FuelSavingsCalculatorTimeFrame timeframe)
        {
            const int monthsPerYear = 12;
            const int weeksPerYear = 52;

            switch (timeframe)
            {
                case FuelSavingsCalculatorTimeFrame.Week:
                    return (milesDriven * weeksPerYear) / monthsPerYear;
                case FuelSavingsCalculatorTimeFrame.Month:
                    return milesDriven;
                case FuelSavingsCalculatorTimeFrame.Year:
                    return milesDriven / monthsPerYear;
                default:
                    throw new ArgumentException("Unknown timeframe passed: " + timeframe);
            }
        }

        private decimal CalculateMonthlyCost(decimal milesDrivenPerMonth, decimal ppg, int mpg)
        {
            var gallonsUsedPerMonth = milesDrivenPerMonth / mpg;
            return gallonsUsedPerMonth * ppg;
        }

        public enum FuelSavingsCalculatorTimeFrame
        {
            Week,
            Month,
            Year
        }
    }
}
