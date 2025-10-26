using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication.ActionsData
{
    internal sealed class CsvWorking
    {
        private Logger loggerCsvWorking = LogManager.GetCurrentClassLogger();

        public void Writer(string csvFilePath, List<CurrencyModel> currencys)
        {
            DeleteFileCb();
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("DigitalCode;LetterCode;Units;Currency;Rate");
            foreach (var currency in currencys)
            {
                csvBuilder.AppendLine(
                    $"{currency.DigitalCode};{currency.LetterCode};{currency.Units};{currency.Currency};{currency.Rate}");
            }

            File.WriteAllText(csvFilePath, csvBuilder.ToString());
        }

        public void Writer(string csvFilePath, DataGridView dataDeposits)
        {
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

        public List<BankDepModel> Reader(string csvFilePath, List<BankDepModel> bankDeposits)
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
                    VariableColor colorRows;
                    DateTime targetDate = Convert.ToDateTime(values[6].Trim());
                    DateTime dateToday = DateTime.Today;
                    if (targetDate < dateToday)
                    {
                        colorRows = VariableColor.R;
                    }
                    else if (targetDate >= dateToday.AddDays(3))
                    {
                        colorRows = VariableColor.G;
                    }
                    else
                    {
                        colorRows = VariableColor.Y;
                    }

                    bankDeposits.Add(new BankDepModel()
                    {
                        Name = values[0].Trim(),
                        Deposit = Convert.ToDouble(GeneralsMethods.AllRemovedCharacters(values[1])),
                        Term = Convert.ToInt32(GeneralsMethods.AllRemovedCharacters(values[2])),
                        Bid = Convert.ToDouble(GeneralsMethods.ParcentRemovedCharacters(values[3].Replace(".", ","))),
                        TotalDeposit = Convert.ToDouble(GeneralsMethods.AllRemovedCharacters(values[4])),
                        DateOpen = Convert.ToDateTime(values[5].Trim()),
                        DateClose = targetDate,
                        CsvCurrency = GeneralsMethods.AllRemovedNumbers(values[1].Trim()),
                        ColorRows = colorRows.ToString(),
                    });
                }
            }

            return bankDeposits;
        }

        private void DeleteFileCb()
        {
            string dirPath = Path.Combine(Directory.GetCurrentDirectory());
            string file = "Курсы*.csv";
            try
            {
                string[] files = Directory.GetFiles(dirPath, file);
                foreach (var item in files)
                {
                    File.Delete(item);
                    loggerCsvWorking.Info($"Удален файл {item}");
                }
            }
            catch (Exception ex)
            {
                loggerCsvWorking.Error($"{ex.Message}");
            }
        }
    }
}