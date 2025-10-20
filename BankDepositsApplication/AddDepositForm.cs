using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BankDepositsApplication.ActionsData;
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication
{
    public partial class AddDepositForm : Form
    {
        #region Fields

        private Logger loggerAddDepositForm = LogManager.GetCurrentClassLogger();
        private List<CurrencyModel> currencys;
        private List<BankDepModel> bankDeposits;
        private GeneralsMethods genMethods = new GeneralsMethods();

        private string[] banks =
        {
            "Т-Банк", "ПСБ", "Сбербанк", "Газпромбанк", "МТС Банк", "ВТБ", "Московский кредитный банк (МКБ)",
            "Альфа-Банк", "Металлинвестбанк", "Ozon Банк", "Совкомбанк", "Уралсиб"
        };

        private MainForm mainForm;

        #endregion

        #region Constructors

        public AddDepositForm(MainForm _mainForm, List<CurrencyModel> _currencys, List<BankDepModel> _bankDeposits)
        {
            mainForm = _mainForm;
            currencys = _currencys;
            bankDeposits = _bankDeposits;
            InitializeComponent();
            mainForm.CurrencyDataReady += OnCurrencyDataReady;
        }

        #endregion

        #region Settings

        private void OnCurrencyDataReady(List<CurrencyModel> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CurrencyModel>>(OnCurrencyDataReady), data);
                return;
            }

            AddedCmbxCurrency(data);
        }

        private void SettingsElementsForm()
        {
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

            btnAddDeposit.Enabled = false;

            cmbxBank.Text = "Выберите банк";
            cmbxBank.ForeColor = Color.Gray;

            tbxDeposit.Text = "Введите депозит";
            tbxDeposit.ForeColor = Color.Gray;

            tbxCurrency.Text = "руб";
            tbxCurrency.Enabled = false;

            cmbxCurrency.Text = "Выберите валюту";
            cmbxCurrency.ForeColor = Color.Gray;

            rBtnMonth.Enabled = true;
            rBtnMonth.Checked = true;
            rBtnDays.Enabled = false;

            tbxTerm.Text = "срок";
            tbxTerm.ForeColor = Color.Gray;

            tbxBid.Text = "%";
            tbxBid.ForeColor = Color.Gray;
        }

        #endregion

        #region Methods

        private void UpdateCurrencyInfo()
        {
            if (cmbxCurrency.SelectedItem != null)
            {
                foreach (var currency in currencys.Where(currency =>
                             cmbxCurrency.SelectedItem.ToString() == currency.Currency))
                {
                    tbxCurrency.Text = currency.LetterCode;
                }

                btnAddDeposit.Enabled = true;
                labelMandatoryCurrency.Visible = false;
            }
            else
            {
                tbxCurrency.Text = "руб";
                btnAddDeposit.Enabled = false;
                labelMandatoryCurrency.Visible = true;
            }
        }

        private void AddedCmbxCurrency(List<CurrencyModel> currencys)
        {
            cmbxCurrency.Items.Clear();
            foreach (var currency in currencys)
            {
                cmbxCurrency.Items.Add(currency.Currency);
            }
        }

        private void AddedCmbxBank(string[] banks)
        {
            Array.Sort(banks);
            foreach (var bank in banks)
            {
                cmbxBank.Items.Add(bank);
            }
        }

        private List<BankDepModel> AddBankDeposit()
        {
            try
            {
                if (chbxCapitalization.Checked)
                {
                    if (tbxCurrency.Text == "руб")
                    {
                        bankDeposits.Add(new BankDepModel
                        {
                            Name = cmbxBank.SelectedItem.ToString(),
                            Deposit = Convert.ToDouble(tbxDeposit.Text),
                            Currency = tbxCurrency.Text,
                            Rate = 1,
                            Term = Convert.ToInt32(tbxTerm.Text),
                            Bid = Convert.ToDouble(tbxBid.Text),
                            DateOpen = Convert.ToDateTime(dtpDateOpen.Value.ToShortDateString()),
                            Capitalization = true
                        });
                    }
                    else
                    {
                        foreach (var currency in currencys)
                        {
                            if (cmbxCurrency.SelectedItem.ToString() == currency.Currency)
                            {
                                bankDeposits.Add(new BankDepModel
                                {
                                    Name = cmbxBank.SelectedItem.ToString(),
                                    Deposit = Convert.ToDouble(tbxDeposit.Text),
                                    Currency = tbxCurrency.Text,
                                    Rate = currency.Rate,
                                    Term = Convert.ToInt32(tbxTerm.Text),
                                    Bid = Convert.ToDouble(tbxBid.Text),
                                    DateOpen = Convert.ToDateTime(dtpDateOpen.Value.ToShortDateString()),
                                    Capitalization = true
                                });
                            }
                        }
                    }
                }
                else
                {
                    if (tbxCurrency.Text == "руб")
                    {
                        bankDeposits.Add(new BankDepModel
                        {
                            Name = cmbxBank.SelectedItem.ToString(),
                            Deposit = Convert.ToDouble(tbxDeposit.Text),
                            Currency = tbxCurrency.Text,
                            Rate = 1,
                            Term = Convert.ToInt32(tbxTerm.Text),
                            Bid = Convert.ToDouble(tbxBid.Text),
                            DateOpen = Convert.ToDateTime(dtpDateOpen.Value.ToShortDateString()),
                            Capitalization = false
                        });
                    }
                    else
                    {
                        foreach (var currency in currencys)
                        {
                            if (cmbxCurrency.SelectedItem.ToString() == currency.Currency)
                            {
                                bankDeposits.Add(new BankDepModel
                                {
                                    Name = cmbxBank.SelectedItem.ToString(),
                                    Deposit = Convert.ToDouble(tbxDeposit.Text),
                                    Currency = tbxCurrency.Text,
                                    Rate = currency.Rate,
                                    Term = Convert.ToInt32(tbxTerm.Text),
                                    Bid = Convert.ToDouble(tbxBid.Text),
                                    DateOpen = Convert.ToDateTime(dtpDateOpen.Value.ToShortDateString()),
                                    Capitalization = false
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loggerAddDepositForm.Error($"{ex.Message}");
            }

            return bankDeposits;
        }

        #endregion

        #region Elements Handlers

        private void AddDepositForm_Load(object sender, EventArgs e)
        {
            SettingsElementsForm();
            AddedCmbxBank(banks);
            AddedCmbxCurrency(currencys);
        }

        private void cmbxBank_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxBank.Text))
            {
                cmbxBank.Text = "Выберите банк";
                cmbxBank.ForeColor = Color.Gray;
            }

            if (cmbxBank.SelectedItem != null)
            {
                btnAddDeposit.Enabled = true;
                labelMandatoryBank.Visible = false;
            }
            else
            {
                btnAddDeposit.Enabled = false;
                labelMandatoryBank.Visible = true;
            }
        }

        private void cmbxBank_Enter(object sender, EventArgs e)
        {
            if (cmbxBank.Items.Count > 0)
            {
                cmbxBank.Text = null;
            }

            cmbxBank.ForeColor = Color.Black;
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
                btnAddDeposit.Enabled = true;
                labelMandatoryDeposit.Visible = false;
            }
            else
            {
                btnAddDeposit.Enabled = false;
                labelMandatoryDeposit.Visible = true;
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

        private void chBxCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (chBxCurrency.Checked)
            {
                cmbxCurrency.Visible = true;
            }
            else
            {
                cmbxCurrency.Visible = false;
                labelMandatoryCurrency.Visible = false;
            }
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

        private void cmbxCurrency_Enter(object sender, EventArgs e)
        {
            if (cmbxCurrency.Items.Count > 0)
            {
                cmbxCurrency.Text = null;
            }

            cmbxCurrency.ForeColor = Color.Black;
        }

        private void cmbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrencyInfo();
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
                btnAddDeposit.Enabled = true;
                labelMandatoryTerm.Visible = false;
            }
            else
            {
                btnAddDeposit.Enabled = false;
                labelMandatoryTerm.Visible = true;
            }
        }

        private void tbxTerm_Enter(object sender, EventArgs e)
        {
            if (!genMethods.IsParseInt(tbxTerm.Text))
            {
                tbxTerm.Text = null;
            }

            tbxTerm.ForeColor = Color.Black;
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
                btnAddDeposit.Enabled = true;
                labelMandatoryBid.Visible = false;
            }
            else
            {
                btnAddDeposit.Enabled = false;
                labelMandatoryBid.Visible = true;
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

        #region Button Action

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                AddBankDeposit();
            }
            catch (Exception ex)
            {
                loggerAddDepositForm.Error($"{ex.Message}");
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}