using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using BankDepositsApplication.Models;
using BankDepositsApplication.WorkFiles;
using HtmlAgilityPack;
using NLog;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace BankDepositsApplication.ActionsData
{
    internal class CentralBankParser : DefaultDataCB
    {
        private Logger loggerCentralBankParser = LogManager.GetCurrentClassLogger();

        private readonly string csvFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), $"Курсы_ЦБ_{dateGetDataCB}.csv");

        private CsvWorking csvWorking = new CsvWorking();

        private readonly string urlCentralBank =
            $@"https://www.cbr.ru/currency_base/daily/?UniDbQuery.Posted=True&UniDbQuery.To={dateGetDataCB}";

        private static string dateGetDataCB = DateTime.Now.ToShortDateString();
        private readonly HttpClient httpClient = new HttpClient();
        private const int countCells = 5;
        private List<CurrencyModel> currencys;

        public CentralBankParser(List<CurrencyModel> _currencys) : base(_currencys)
        {
            currencys = _currencys;
        }

        private List<CurrencyModel> GetRate()
        {
            loggerCentralBankParser.Info("Запущен процесс получения курса валют ЦБ РФ...");
            try
            {
                loggerCentralBankParser.Info($"Подключение по адресу: {urlCentralBank}");
                var httpResponseMessage = httpClient.GetAsync(urlCentralBank).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    loggerCentralBankParser.Info($"Подключение прошло успешно. {httpResponseMessage.StatusCode}");
                    string htmlResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(htmlResponse))
                    {
                        HtmlDocument document = new HtmlDocument();
                        document.LoadHtml(htmlResponse);
                        string elementId = "content";
                        var container = document.GetElementbyId($"{elementId}");
                        if (container != null)
                        {
                            var tableBody = document.GetElementbyId("content").ChildNodes.FindFirst("tbody")
                                .ChildNodes
                                .Where(x => x.Name == "tr").Skip(1).ToArray();
                            loggerCentralBankParser.Info("Извлечение данных...");
                            int _countCells = document.GetElementbyId("content").ChildNodes.FindFirst("tbody")
                                .ChildNodes
                                .FindFirst("tr").ChildNodes.Where(c => c.Name == "th").Count();
                            int allElements = tableBody.Length;
                            try
                            {
                                if (_countCells != countCells)
                                {
                                    currencys = DefaultRate();
                                    throw new ArgumentOutOfRangeException(
                                        $"Столбцов больше или меньше, чем должно быть. Проверьте структуру сайта. Добавлены данные по умолчанию.");
                                }

                                foreach (var tableRow in tableBody)
                                {
                                    string cellDigitalCode = tableRow.SelectSingleNode(".//td[1]").InnerHtml;
                                    string cellLetterCode = tableRow.SelectSingleNode(".//td[2]").InnerHtml;
                                    string cellUnits = tableRow.SelectSingleNode(".//td[3]").InnerHtml;
                                    string cellCurrency = tableRow.SelectSingleNode(".//td[4]").InnerHtml;
                                    string cellRate = tableRow.SelectSingleNode(".//td[5]").InnerHtml;
                                    currencys.Add(new CurrencyModel
                                    {
                                        DigitalCode = Convert.ToInt32(cellDigitalCode),
                                        LetterCode = cellLetterCode,
                                        Units = Convert.ToInt32(cellUnits),
                                        Currency = cellCurrency,
                                        Rate = Math.Round(Convert.ToDouble(cellRate), 4)
                                    });
                                }

                                if (currencys != null)
                                {
                                    csvWorking.Writer(csvFilePath, currencys);
                                    loggerCentralBankParser.Info(
                                        $"Данные успешно получены. Количество {currencys.Count} из {allElements}.");
                                }
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                loggerCentralBankParser.Error($"{ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                loggerCentralBankParser.Error($"{ex.Message}");
                            }
                        }
                        else
                        {
                            throw new HtmlWebException($"Не получилось найти элемент по Id {elementId}.");
                        }
                    }
                    else
                    {
                        throw new HttpRequestException($"Содержимое HTTP-ответа пришел пустой или не содержит данные.");
                    }
                }
                else
                {
                    currencys = DefaultRate();
                    csvWorking.Writer(csvFilePath, currencys);
                    throw new HttpRequestException(
                        $"Подключиться не удалось. {httpResponseMessage.StatusCode}. Добавлены данные по умолчанию.");
                }
            }
            catch (HtmlWebException hwEx)
            {
                loggerCentralBankParser.Error($"{hwEx}");
            }
            catch (HttpRequestException hrEx)
            {
                loggerCentralBankParser.Error($"{hrEx}");
            }
            catch (Exception ex)
            {
                loggerCentralBankParser.Error($"{ex.Message}");
            }

            return currencys;
        }

        internal List<CurrencyModel> CB_Parser()
        {
            try
            {
                currencys = GetRate();
                if (currencys == null || currencys.Count == 0)
                {
                    currencys = DefaultRate();
                }
            }
            catch (Exception ex)
            {
                loggerCentralBankParser.Error($"{ex.Message}");
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return currencys;
        }
    }
}