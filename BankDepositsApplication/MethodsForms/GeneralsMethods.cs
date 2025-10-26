using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BankDepositsApplication.MethodsForms
{
    public sealed class GeneralsMethods
    {
        public static string AllRemovedCharacters(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Regex.Replace(value, @"[^\d.]", "");
        }

        public static string ParcentRemovedCharacters(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Regex.Replace(value, @"[ %]", "");
        }

        public static string AllRemovedNumbers(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Regex.Replace(value, @"[^a-zA-Zа-яА-Я]", "");
        }

        public static bool IsParseInt(string text)
        {
            return Int32.TryParse(text, out int value);
        }

        public static bool IsParseDouble(string text)
        {
            return Double.TryParse(text, out double value);
        }

        public string FormatNumberRows(double value)
        {
            return value.ToString("N0", CultureInfo.InvariantCulture);
        }

        public static double CalculationTotalDeposit(double dep, double rate, double bid, int term,
            bool checkCapitalization)
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