using System;
using System.Drawing;

namespace BankDepositsApplication.Models
{
    public sealed class DepositUpdatedEventArgs : EventArgs
    {
        public string BankName { get; set; }
        public double Deposit { get; set; }
        public int Term { get; set; }
        public double Bid { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime DateClose { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public bool Capitalization { get; set; }
        public Color ColorRow { get; set; }
    }
}