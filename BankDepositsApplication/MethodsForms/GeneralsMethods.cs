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
    }
}