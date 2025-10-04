using System;

namespace BankDepositsApplication.Models
{
    public class BankDepModel
    {
        internal string Name { get; set; }
        internal double Deposit { get; set; }
        internal string Currency { get; set; }
        internal double Rate { get; set; }
        internal int Term { get; set; }
        internal double Bid { get; set; }
        internal DateTime DateOpen { get; set; }
        internal double TotalDeposit { get; set; }
        internal DateTime DateClose { get; set; }
        internal bool Capitalization { get; set; }
        internal string CsvCurrency { get; set; }
    }
}