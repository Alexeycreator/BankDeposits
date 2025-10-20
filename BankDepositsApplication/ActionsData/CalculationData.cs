using System;
using System.Collections.Generic;
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication.ActionsData
{
    internal sealed class CalculationData
    {
        private Logger loggerCalculationData = LogManager.GetCurrentClassLogger();
        private List<BankDepModel> bankDeposits;
        private GeneralsMethods genMethods = new GeneralsMethods();

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
                    dep.TotalDeposit = genMethods.CalculationTotalDeposit(dep.Deposit, dep.Rate, dep.Bid, dep.Term,
                        dep.Capitalization);
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