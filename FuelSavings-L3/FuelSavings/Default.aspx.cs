using FuelSavings.Logic;
using System;
using System.Web.UI;
using static FuelSavings.Logic.FuelSavingsCalculator;

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

            FuelSavingsCalculatorTimeFrame timeframe;
            Enum.TryParse<FuelSavingsCalculatorTimeFrame>(ddMilesDrivenTimeFrame.SelectedValue, out timeframe);

            var calculator = new FuelSavingsCalculator(
                Convert.ToInt16(txtMilesDriven.Text),
                timeframe,
                Convert.ToInt16(txtTradeMpg.Text),
                Convert.ToInt16(txtNewMpg.Text),
                Convert.ToDecimal(txtPpg.Text));

            return calculator.CalculateSavingsPerMonth();
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