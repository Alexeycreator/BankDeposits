using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using BankDepositsApplication.Models;

namespace BankDepositsApplication.ActionsData
{
    internal sealed class CsvWriter
    {
        internal void Writer(string csvFilePath, List<CurrencyModel> currencys)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("DigitalCode;LetterCode;Units;Currency;Rate");
            foreach (var currency in currencys)
            {
                csvBuilder.AppendLine(
                    $"{currency.DigitalCode};{currency.LetterCode};{currency.Units};{currency.Currency};{currency.Rate}");
            }

            File.WriteAllText(csvFilePath, csvBuilder.ToString());
        }
    }
}