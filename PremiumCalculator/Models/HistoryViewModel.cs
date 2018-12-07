using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculator.Models
{
    public class HistoryViewModel
    {
        public string Date { get; set; }

        public double PolicyFee { get; set; }

        public double Premium { get; set; }

        public double Insured { get; set; }
    }
}