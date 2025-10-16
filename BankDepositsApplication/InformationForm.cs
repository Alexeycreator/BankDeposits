using System;
using System.Windows.Forms;
using NLog.LayoutRenderers;

namespace BankDepositsApplication
{
    public partial class InformationForm : Form
    {
        private string _bankName;
        private double _deposit;
        private int _term;
        private double _bid;
        private DateTime _date;
        private string _currency;

        public InformationForm(string bankName, double deposit, int term, double bid, DateTime date, string currency)
        {
            _bankName = bankName;
            _deposit = deposit;
            _term = term;
            _bid = bid;
            _date = date;
            _currency = currency;
            InitializeComponent();
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            rBtnDays.Enabled = false;
            cmbxBank.Enabled = false;
            cmbxBank.Text = _bankName;
            tbxDeposit.Text = _deposit.ToString();
            tbxTerm.Text = _term.ToString();
            tbxBid.Text = _bid.ToString();
            dtpDateOpen.Value = _date;
            tbxCurrency.Text = _currency;
        }
    }
}