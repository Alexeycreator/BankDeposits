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

        private string csvFilePath =
            $@"C:\Users\Алексей\Desktop\Учеба\github\WebSocketApplication\ServerConsoleApplication\bin\Debug\CentralBank\02.10.2025\Rate_10-21.csv";

        private List<CurrencyModel> currencys;

        public DefaultDataCB(List<CurrencyModel> _currencys)
        {
            currencys = _currencys;
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