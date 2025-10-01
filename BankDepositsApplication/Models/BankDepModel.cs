using System;

namespace BankDepositsApplication.Models
{
    internal sealed class BankDepModel
    {
        internal string Name { get; set; }
        internal decimal Deposit { get; set; }
        internal int Term { get; set; }
        internal double Bid { get; set; }
        internal decimal TotalDeposit { get; set; }
        internal DateTime DateOpen { get; set; }
        internal DateTime DateClose { get; set; }
    }
}