namespace BankDepositsApplication.Models
{
    public sealed class CurrencyModel
    {
        internal int DigitalCode { get; set; }
        internal string LetterCode { get; set; }
        internal int Units { get; set; }
        internal string Currency { get; set; }
        internal double Rate { get; set; }
    }
}