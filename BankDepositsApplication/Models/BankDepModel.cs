using System;

namespace BankDepositsApplication.Models
{
    public sealed class BankDepModel
    {
        public string Name { get; set; }
        public double Deposit { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public int Term { get; set; }
        public double Bid { get; set; }
        public DateTime DateOpen { get; set; }
        public double TotalDeposit { get; set; }
        public DateTime DateClose { get; set; }
        public bool Capitalization { get; set; }
        public string CsvCurrency { get; set; }
        public string ColorRows { get; set; }
    }
}