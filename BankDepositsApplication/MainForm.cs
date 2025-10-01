using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankDepositsApplication
{
    public partial class MainForm : Form
    {
        private string nameBank;
        private DateTime dateStart;
        private int term;
        private decimal deposit;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Methods

        private void InitDataGrid()
        {
            RowsDataGridAdded();
        }

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
            dgvPrintInfo.Rows[0].Cells["Name"].Value = nameBank;
            dgvPrintInfo.Rows[0].Cells["Deposit"].Value = deposit;
            dgvPrintInfo.Rows[0].Cells["Term"].Value = term;
            dgvPrintInfo.Rows[0].Cells["DateStart"].Value = dateStart;
        }

        #endregion


        private void btnCalc_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ColomnsDataGridAdded();
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            AddDepositForm addDepositForm = new AddDepositForm();
            addDepositForm.ShowDialog();
        }
    }
}