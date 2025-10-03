using System;
using System.Collections.Generic;
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
                    if (dep.Capitalization)
                    {
                        dep.TotalDeposit = dep.Deposit * Math.Pow(dep.Rate + dep.Bid / 100, dep.Term / 12);
                    }
                    else
                    {
                        dep.TotalDeposit = dep.Deposit * (dep.Rate + (dep.Bid / 100) * dep.Term / 12);
                    }

                    dep.DateClose = dep.DateOpen.AddMonths(dep.Term);
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