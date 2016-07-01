using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuelSavings
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void onBtnCalculateClick(object sender, EventArgs e)
        {
            litDateModified.Text = DateTime.Now.ToLongTimeString();
            trResult.Visible = true;
            var savingsOrLoss = CalculateSavings();
            litSavingsOrLoss.Text = savingsOrLoss.ToString();
            lblSavingsOrLoss.InnerText = savingsOrLoss > 0 ? "Savings" : "Loss";
        }

        private decimal CalculateSavings()
        {
            if (!NecessaryDataIsProvidedToCalculateSavings())
            {
                return 0;
            }

            return CalculateSavingsPerMonth(
                Convert.ToInt16(txtMilesDriven.Text),
                ddMilesDrivenTimeFrame.SelectedValue,
                Convert.ToInt16(txtTradeMpg.Text),
                Convert.ToInt16(txtNewMpg.Text),
                Convert.ToDecimal(txtPpg.Text)
                );
        }

        public decimal CalculateMilesDrivenPerMonth(int milesDriven, string milesDrivenTimeframe)
        {
            const int monthsPerYear = 12;
            const int weeksPerYear = 52;

            switch (milesDrivenTimeframe)
            {
                case "Week":
                    return (milesDriven * weeksPerYear) / monthsPerYear;
                case "Month":
                    return milesDriven;
                case "Year":
                    return milesDriven / monthsPerYear;
                default:
                    throw new ArgumentException("Unknown milesDrivenTimeframe passed: " + milesDrivenTimeframe);
            }
        }

        private decimal CalculateSavingsPerMonth(int milesDriven, string milesDrivenTimeframe, int tradeMpg, int newMpg, decimal ppg)
        {
            if (string.IsNullOrEmpty(txtMilesDriven.Text))
            {
                return 0;
            }

            var milesDrivenPerMonth = CalculateMilesDrivenPerMonth(milesDriven, milesDrivenTimeframe);
            var tradeFuelCostPerMonth = CalculateMonthlyCost(milesDrivenPerMonth, ppg, tradeMpg);
            var newFuelCostPerMonth = CalculateMonthlyCost(milesDrivenPerMonth, ppg, newMpg);
            var savingsPerMonth = tradeFuelCostPerMonth - newFuelCostPerMonth;

            return Math.Round(savingsPerMonth, 2);
        }

        private decimal CalculateMonthlyCost(decimal milesDrivenPerMonth, decimal ppg, int mpg)
        {
            var gallonsUsedPerMonth = milesDrivenPerMonth / mpg;
            return gallonsUsedPerMonth * ppg;
        }

        private bool NecessaryDataIsProvidedToCalculateSavings()
        {
            return txtNewMpg.Text != string.Empty
              && txtTradeMpg.Text != string.Empty
              && txtPpg.Text != string.Empty
              && txtMilesDriven.Text != string.Empty;
        }
    }
}