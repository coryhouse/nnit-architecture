using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelSavings.UI.Models
{
    public class FuelSavingsViewModel
    {
        [Required]
        [Range(0, 100, ErrorMessage = "Enter number between 0 to 100")]
        public int NewMPG { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Enter number between 0 to 100")]
        public int TradeMPG { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between $1.00 to $5.00")]
        public decimal PricePerGallon { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Enter number between 0 to 100,000")]
        public int MilesDriven { get; set; }

        [Required]
        public string MilesDrivenTimeframe { get; set; }

        public string ResultLabel { get; set; }

        public decimal Result { get; set; }

        public string DateModified { get; set; }

        public static IEnumerable<string> Timeframes = new List<string>() {
            "week",
            "month",
            "year"
        };
    }
}