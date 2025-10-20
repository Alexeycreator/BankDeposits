using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BankDepositsApplication.MethodsForms
{
    public sealed class GeneralsMethods
    {
        public string RemovedCharacters(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return Regex.Replace(value, @"[^\d.]", "");
        }

        public string RemovedNumbers(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return Regex.Replace(value, @"[^a-zA-Zа-яА-Я]", "");
        }

        public bool IsParseInt(string text)
        {
            return Int32.TryParse(text, out int value);
        }

        public bool IsParseDouble(string text)
        {
            return Double.TryParse(text, out double value);
        }

        public string FormatNumberRows(double value)
        {
            return value.ToString("N0", CultureInfo.InvariantCulture);
        }

        public double CalculationTotalDeposit(double dep, double rate, double bid, int term, bool checkCapitalization)
        {
            if (checkCapitalization)
            {
                return dep * Math.Pow(rate + bid / 100, term / 12);
            }
            else
            {
                return dep * (rate + (bid / 100) * term / 12);
            }
        }
    }
}