using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDepositsApplication.ActionsData;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication
{
    public partial class MainForm : Form
    {
        private Logger loggerMainForm = LogManager.GetCurrentClassLogger();
        private List<CurrencyModel> currencys = new List<CurrencyModel>();
        private List<BankDepModel> bankDeposits = new List<BankDepModel>();
        public event Action<List<CurrencyModel>> CurrencyDataReady;

        public MainForm()
        {
            InitializeComponent();
            loggerMainForm.Info("Приложение запущено.");
        }

        #region Methods

        private void ColomnsDataGridAdded()
        {
            dgvPrintInfo.Columns.Add("Name", "Наименование банка");
            dgvPrintInfo.Columns.Add("Deposit", "Внесенная сумма");
            dgvPrintInfo.Columns.Add("Term", "Срок");
            dgvPrintInfo.Columns.Add("Bid", "Ставка");
            dgvPrintInfo.Columns.Add("TotalDeposit", "Итоговая сумма");
            dgvPrintInfo.Columns.Add("DateOpen", "Дата открытия вклада");
            dgvPrintInfo.Columns.Add("DateClose", "Дата закрытия вклада");
        }

        private void RowsDataGridAdded()
        {
            try
            {
                foreach (var bankDep in bankDeposits)
                {
                    var cellName = bankDep.Name;
                    var cellDeposit = $"{FormatNumberRows(bankDep.Deposit)} {bankDep.Currency}";
                    var cellTerm = $"{bankDep.Term} мес";
                    var cellBid = $"{bankDep.Bid} %";
                    var cellTotalDeposit = $"{FormatNumberRows(bankDep.TotalDeposit)} руб";
                    var cellDateOpen = bankDep.DateOpen.ToShortDateString();
                    var cellDateClose = bankDep.DateClose.ToShortDateString();
                    dgvPrintInfo.Rows.Add(cellName, cellDeposit, cellTerm, cellBid, cellTotalDeposit, cellDateOpen,
                        cellDateClose);
                }

                SortRowsData();
            }
            catch (Exception ex)
            {
                loggerMainForm.Error($"{ex.Message}");
            }
        }

        private void SortRowsData()
        {
            dgvPrintInfo.Sort(dgvPrintInfo.Columns["DateClose"], ListSortDirection.Ascending);
        }

        private string FormatNumberRows(double value)
        {
            return value.ToString("N0", CultureInfo.InvariantCulture);
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            ColomnsDataGridAdded();
            Thread test = new Thread(() =>
            {
                CentralBankParser cbParser = new CentralBankParser(currencys);
                var result = cbParser.CB_Parser();

                CurrencyDataReady?.Invoke(result);
            });
            test.Start();
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            bankDeposits = new List<BankDepModel>();
            AddDepositForm addDepositForm = new AddDepositForm(this, currencys, bankDeposits);
            addDepositForm.ShowDialog();
            CalculationData calcData = new CalculationData(bankDeposits);
            calcData.GetCalcDeposits();
            RowsDataGridAdded();
        }
    }
}