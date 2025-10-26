using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication.ActionsData
{
    internal sealed class CalculationData
    {
        private Logger loggerCalculationData = LogManager.GetCurrentClassLogger();
        private List<BankDepModel> bankDeposits;

        public CalculationData(List<BankDepModel> _bankDeposits)
        {
            bankDeposits = _bankDeposits;
        }

        private List<BankDepModel> CalcDataDep()
        {
            try
            {
                foreach (var dep in bankDeposits)
                {
                    switch (dep.TypeTerm)
                    {
                        case "m":
                            dep.TotalDeposit = GeneralsMethods.CalculationTotalDeposit(dep.Deposit, dep.Rate, dep.Bid,
                                dep.Term,
                                dep.Capitalization);
                            dep.DateClose = dep.DateOpen.AddMonths(dep.Term);
                            break;
                        case "d":
                            dep.TotalDeposit = GeneralsMethods.CalculationTotalDeposit(dep.Deposit, dep.Rate, dep.Bid,
                                dep.Term,
                                dep.Capitalization);
                            dep.DateClose = dep.DateOpen.AddDays(dep.Term);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                loggerCalculationData.Error($"{ex.Message}");
            }

            return bankDeposits;
        }

        internal void GetCalcDeposits()
        {
            bankDeposits = CalcDataDep();
        }
    }
}