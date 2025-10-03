using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication.WorkFiles
{
    internal class DefaultDataCB
    {
        private Logger loggerDefaultDataCB = LogManager.GetCurrentClassLogger();

        private readonly string csvFilePath;

        private List<CurrencyModel> currencys;

        public DefaultDataCB(List<CurrencyModel> _currencys)
        {
            currencys = _currencys;
            string dirPath = Path.Combine(Directory.GetCurrentDirectory());
            csvFilePath = FindRateFile(dirPath);
        }

        private string FindRateFile(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                throw new DirectoryNotFoundException($"Директории не существует или не найдена. {dirPath}");
            }

            string serchFile = "Курсы*.csv";
            var rateFile = Directory.GetFiles(dirPath, serchFile);
            if (rateFile.Length == 0)
            {
                throw new FileNotFoundException($"Файл {serchFile} не найде в директории {dirPath}");
            }

            if (rateFile.Length > 1)
            {
                return rateFile.OrderByDescending(f => f).First();
            }

            return rateFile[0];
        }

        private protected List<CurrencyModel> DefaultRate()
        {
            loggerDefaultDataCB.Info("Получение старых данных от ЦБ за 02.10.2025");
            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var data = line.Split(';');
                    currencys.Add(new CurrencyModel
                    {
                        DigitalCode = Convert.ToInt32(data[0]),
                        LetterCode = data[1],
                        Units = Convert.ToInt32(data[2]),
                        Currency = data[3],
                        Rate = Math.Round(Convert.ToDouble(data[4]), 4)
                    });
                }
            }

            return currencys;
        }
    }
}