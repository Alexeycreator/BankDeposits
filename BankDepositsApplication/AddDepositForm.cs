using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BankDepositsApplication.Models;

namespace BankDepositsApplication
{
    public partial class AddDepositForm : Form
    {
        private List<BankDepModel> bankDeposits = new List<BankDepModel>();

        public AddDepositForm()
        {
            InitializeComponent();
        }

        private void AddDepositForm_Load(object sender, EventArgs e)
        {
            SettingsElementsForm();
        }

        #region Settings

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

            cmbxCurrency.Text = "Выберите валюту";
            cmbxCurrency.ForeColor = Color.Gray;
        }

        #endregion

        #region Methods

        private bool IsParseInt(string text)
        {
            return Int32.TryParse(text, out int value);
        }

        private bool IsParseDecimal(string text)
        {
            return Decimal.TryParse(text, out decimal value);
        }

        private void CheckCorrFilling()
        {
            if (cmbxBank.SelectedItem == null)
            {
                labelMandatoryBank.Visible = true;
            }
            else
            {
                labelMandatoryBank.Visible = false;
            }
        }

        #endregion

        #region Elements Handlers

        private void cmbxBank_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxBank.Text))
            {
                cmbxBank.Text = "Выберите банк";
                cmbxBank.ForeColor = Color.Gray;
            }

            btnAddDeposit.Enabled = true;
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

            btnAddDeposit.Enabled = true;
        }

        private void tbxDeposit_Enter(object sender, EventArgs e)
        {
            if (!IsParseInt(tbxDeposit.Text))
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
            }
        }

        private void cmbxCurrency_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxCurrency.Text))
            {
                cmbxCurrency.Text = "Выберите валюту";
                cmbxCurrency.ForeColor = Color.Gray;
            }

            btnAddDeposit.Enabled = true;
        }

        private void cmbxCurrency_Enter(object sender, EventArgs e)
        {
            if (cmbxCurrency.Items.Count > 0)
            {
                cmbxCurrency.Text = null;
            }

            cmbxCurrency.ForeColor = Color.Black;
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
                CheckCorrFilling();
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}