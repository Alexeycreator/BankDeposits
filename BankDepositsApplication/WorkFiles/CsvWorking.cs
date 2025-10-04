using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BankDepositsApplication.Models;

namespace BankDepositsApplication.ActionsData
{
    internal sealed class CsvWorking
    {
        internal void Writer(string csvFilePath, List<CurrencyModel> currencys)
        {
            CheckExistsFile(csvFilePath);
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("DigitalCode;LetterCode;Units;Currency;Rate");
            foreach (var currency in currencys)
            {
                csvBuilder.AppendLine(
                    $"{currency.DigitalCode};{currency.LetterCode};{currency.Units};{currency.Currency};{currency.Rate}");
            }

            File.WriteAllText(csvFilePath, csvBuilder.ToString());
        }

        internal void Writer(string csvFilePath, List<BankDepModel> bankDeposits, DataGridView dataDeposits)
        {
            CheckExistsFile(csvFilePath);
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Name;Deposit;Term;Bid;TotalDeposit;DateOpen;DateClose");

            foreach (DataGridViewRow row in dataDeposits.Rows)
            {
                if (row.IsNewRow) continue;

                var rowData = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (dataDeposits.Columns[cell.ColumnIndex].Visible)
                    {
                        rowData.Add(cell.Value?.ToString() ?? "");
                    }
                }

                csvBuilder.AppendLine(string.Join(";", rowData));
            }

            File.WriteAllText(csvFilePath, csvBuilder.ToString());
        }

        internal List<BankDepModel> Reader(string csvFilePath, List<BankDepModel> bankDeposits)
        {
            if (!File.Exists(csvFilePath))
            {
                File.Create(csvFilePath);
                MessageBox.Show($"Файл с данными не был загружен. Таблица пустая!");
            }

            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    bankDeposits.Add(new BankDepModel
                    {
                        Name = values[0].Trim(),
                        Deposit = Convert.ToDouble(RemovedCharacters(values[1])),
                        Term = Convert.ToInt32(RemovedCharacters(values[2])),
                        Bid = Convert.ToDouble(RemovedCharacters(values[3].Replace(".", ","))),
                        TotalDeposit = Convert.ToDouble(RemovedCharacters(values[4])),
                        DateOpen = Convert.ToDateTime(values[5].Trim()),
                        DateClose = Convert.ToDateTime(values[6].Trim()),
                        CsvCurrency = RemovedNumbers(values[1].Trim())
                    });
                }
            }

            return bankDeposits;
        }

        private void CheckExistsFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        private string RemovedCharacters(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return Regex.Replace(value, @"[^\d.]", "");
        }

        private string RemovedNumbers(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return Regex.Replace(value, @"[^a-zA-Zа-яА-Я]", "");
        }
    }
}