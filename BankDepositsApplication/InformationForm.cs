using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication
{
    public partial class InformationForm : Form
    {
        #region Fields

        private Logger loggerInformationForm = LogManager.GetCurrentClassLogger();
        private string _bankName;
        private double _deposit;
        private int _term;
        private double _bid;
        private DateTime _date;
        private string _currency;
        private bool _capitalization;
        private GeneralsMethods genMethods = new GeneralsMethods();
        private List<CurrencyModel> currencys;
        private List<BankDepModel> bankDeposits;
        private double updatedRate = 1;
        public event EventHandler<DepositUpdatedEventArgs> DepositUpdated;

        #endregion

        #region Constructors

        public InformationForm(string bankName, double deposit, int term, double bid, DateTime date, string currency,
            bool capitalization, List<CurrencyModel> currencysData)
        {
            _bankName = bankName;
            _deposit = deposit;
            _term = term;
            _bid = bid;
            _date = date;
            _currency = currency;
            _capitalization = capitalization;
            currencys = currencysData;
            InitializeComponent();
        }

        #endregion

        #region Elements Handlers

        private void InformationForm_Load(object sender, EventArgs e)
        {
            rBtnMonth.Enabled = true;
            rBtnMonth.Checked = true;
            rBtnDays.Enabled = false;
            cmbxBank.Enabled = false;
            cmbxBank.Text = _bankName;
            tbxDeposit.Text = _deposit.ToString();
            tbxTerm.Text = _term.ToString();
            tbxBid.Text = _bid.ToString();
            dtpDateOpen.Value = _date;
            tbxCurrency.Text = _currency;
            chbxCapitalization.Checked = _capitalization;

            labelMandatoryBank.Visible = false;
            labelMandatoryBank.ForeColor = Color.Red;
            labelMandatoryDeposit.Visible = false;
            labelMandatoryDeposit.ForeColor = Color.Red;
            labelMandatoryCurrency.Visible = false;
            labelMandatoryCurrency.ForeColor = Color.Red;
            labelMandatoryTerm.Visible = false;
            labelMandatoryTerm.ForeColor = Color.Red;
            labelMandatoryBid.Visible = false;
            labelMandatoryBid.ForeColor = Color.Red;
            cmbxCurrency.Visible = false;

            cmbxCurrency.Items.Add("Российский рубль");
            foreach (var currency in currencys)
            {
                cmbxCurrency.Items.Add(currency.Currency);
            }

            tbxCurrency.Enabled = false;
        }

        private void chBxCurrency_CheckedChanged(object sender, EventArgs e)
        {
            cmbxCurrency.Visible = chBxCurrency.Checked;
        }

        private void cmbxBank_Enter(object sender, EventArgs e)
        {
            if (cmbxBank.Items.Count > 0)
            {
                cmbxBank.Text = null;
            }

            cmbxBank.ForeColor = Color.Black;
        }

        private void cmbxBank_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxBank.Text))
            {
                cmbxBank.Text = "Выберите банк";
                cmbxBank.ForeColor = Color.Gray;
                MessageBox.Show($"Поле наименования банка пустое. Проверьте существует ли банк в таблице");
            }

            if (cmbxBank.SelectedItem != null)
            {
                btnChangeDeposit.Enabled = true;
                labelMandatoryBank.Visible = false;
            }
            else
            {
                btnChangeDeposit.Enabled = false;
                labelMandatoryBank.Visible = true;
            }
        }

        private void tbxDeposit_Enter(object sender, EventArgs e)
        {
            if (!genMethods.IsParseInt(tbxDeposit.Text))
            {
                tbxDeposit.Text = null;
            }

            tbxDeposit.ForeColor = Color.Black;
        }

        private void tbxDeposit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxDeposit.Text))
            {
                tbxDeposit.Text = "Введите депозит";
                tbxDeposit.ForeColor = Color.Gray;
            }

            if (tbxDeposit.Text != null && genMethods.IsParseInt(tbxDeposit.Text))
            {
                btnChangeDeposit.Enabled = true;
                labelMandatoryDeposit.Visible = false;
            }
            else
            {
                btnChangeDeposit.Enabled = false;
                labelMandatoryDeposit.Visible = true;
            }
        }

        private void cmbxCurrency_Enter(object sender, EventArgs e)
        {
            if (cmbxCurrency.Items.Count > 0)
            {
                cmbxCurrency.Text = null;
            }

            cmbxCurrency.ForeColor = Color.Black;
        }

        private void cmbxCurrency_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxCurrency.Text))
            {
                cmbxCurrency.Text = "Выберите валюту";
                cmbxCurrency.ForeColor = Color.Gray;
            }

            UpdateCurrencyInfo();
        }

        private void cmbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrencyInfo();
        }

        private void tbxTerm_Enter(object sender, EventArgs e)
        {
            if (!genMethods.IsParseInt(tbxTerm.Text))
            {
                tbxTerm.Text = null;
            }

            tbxTerm.ForeColor = Color.Black;
        }

        private void tbxTerm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTerm.Text))
            {
                tbxTerm.Text = "срок";
                tbxTerm.ForeColor = Color.Gray;
            }

            if (tbxTerm != null && genMethods.IsParseInt(tbxTerm.Text))
            {
                btnChangeDeposit.Enabled = true;
                labelMandatoryTerm.Visible = false;
            }
            else
            {
                btnChangeDeposit.Enabled = false;
                labelMandatoryTerm.Visible = true;
            }
        }

        private void tbxBid_Enter(object sender, EventArgs e)
        {
            if (!genMethods.IsParseDouble(tbxBid.Text))
            {
                tbxBid.Text = null;
            }

            tbxBid.ForeColor = Color.Black;
        }

        private void tbxBid_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxTerm.Text))
            {
                tbxBid.Text = "%";
                tbxBid.ForeColor = Color.Gray;
            }

            if (tbxTerm != null && genMethods.IsParseInt(tbxTerm.Text))
            {
                btnChangeDeposit.Enabled = true;
                labelMandatoryBid.Visible = false;
            }
            else
            {
                btnChangeDeposit.Enabled = false;
                labelMandatoryBid.Visible = true;
            }
        }

        private void tbxBid_TextChanged(object sender, EventArgs e)
        {
            if (tbxBid.Text.Length > 4)
            {
                MessageBox.Show($"Процентная ставка должна иметь вид 00.0", "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbxBid.Text = null;
            }
        }

        #endregion

        #region Methods

        private void UpdateCurrencyInfo()
        {
            if (cmbxCurrency.SelectedItem != null)
            {
                if (cmbxCurrency.Text == "Российский рубль")
                {
                    tbxCurrency.Text = "руб";
                    updatedRate = 1;
                }
                else
                {
                    foreach (var currency in currencys.Where(currency =>
                                 cmbxCurrency.SelectedItem.ToString() == currency.Currency))
                    {
                        tbxCurrency.Text = currency.LetterCode;
                        updatedRate = currency.Rate;
                    }
                }


                btnChangeDeposit.Enabled = true;
                labelMandatoryCurrency.Visible = false;
            }
            else
            {
                btnChangeDeposit.Enabled = false;
                labelMandatoryCurrency.Visible = true;
            }
        }

        private void ChangeBankDeposit()
        {
            string updatedBankName = cmbxBank.Text;
            double updatedDeposit = Convert.ToDouble(tbxDeposit.Text);
            int updatedTerm = Convert.ToInt32(tbxTerm.Text);
            double updatedBid = Convert.ToDouble(tbxBid.Text);
            DateTime updatedDateOpen = dtpDateOpen.Value;
            DateTime updatedDateClose = updatedDateOpen.AddMonths(updatedTerm);
            string updatedCurrency = tbxCurrency.Text;
            bool updatedCapitalization = chbxCapitalization.Checked;

            /*foreach (var cur in currencys.Where(cur => updatedCurrency == _currency))
            {
                updatedRate = cur.Rate;
            }*/

            DepositUpdated?.Invoke(this, new DepositUpdatedEventArgs()
            {
                BankName = updatedBankName,
                Deposit = updatedDeposit,
                Term = updatedTerm,
                Bid = updatedBid,
                DateOpen = updatedDateOpen,
                DateClose = updatedDateClose,
                Currency = updatedCurrency,
                Capitalization = updatedCapitalization,
                Rate = updatedRate
            });
        }

        #endregion

        #region Buttons Action

        private void btnChangeDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeBankDeposit();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                loggerInformationForm.Error($"{ex.Message}");
            }
        }

        #endregion

        private void chbxCapitalization_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}