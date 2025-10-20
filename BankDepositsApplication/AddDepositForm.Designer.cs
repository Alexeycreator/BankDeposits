using System.ComponentModel;

namespace BankDepositsApplication
{
    partial class AddDepositForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDepositForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBank = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.cmbxBank = new System.Windows.Forms.ComboBox();
            this.rBtnMonth = new System.Windows.Forms.RadioButton();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.tbxDeposit = new System.Windows.Forms.TextBox();
            this.labelTerm = new System.Windows.Forms.Label();
            this.labelBid = new System.Windows.Forms.Label();
            this.labelDateOpen = new System.Windows.Forms.Label();
            this.tbxTerm = new System.Windows.Forms.TextBox();
            this.rBtnDays = new System.Windows.Forms.RadioButton();
            this.dtpDateOpen = new System.Windows.Forms.DateTimePicker();
            this.tbxBid = new System.Windows.Forms.TextBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.tbxCurrency = new System.Windows.Forms.TextBox();
            this.chBxCurrency = new System.Windows.Forms.CheckBox();
            this.cmbxCurrency = new System.Windows.Forms.ComboBox();
            this.labelMandatoryBank = new System.Windows.Forms.Label();
            this.labelMandatoryDeposit = new System.Windows.Forms.Label();
            this.labelMandatoryCurrency = new System.Windows.Forms.Label();
            this.labelMandatoryTerm = new System.Windows.Forms.Label();
            this.labelMandatoryBid = new System.Windows.Forms.Label();
            this.chbxCapitalization = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTitle.Location = new System.Drawing.Point(90, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(191, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Добавление вклада";
            // 
            // labelBank
            // 
            this.labelBank.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBank.Location = new System.Drawing.Point(12, 60);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(48, 23);
            this.labelBank.TabIndex = 1;
            this.labelBank.Text = "Банк";
            // 
            // labelDeposit
            // 
            this.labelDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeposit.Location = new System.Drawing.Point(14, 124);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(163, 23);
            this.labelDeposit.TabIndex = 2;
            this.labelDeposit.Text = "Внесенная сумма";
            // 
            // cmbxBank
            // 
            this.cmbxBank.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbxBank.FormattingEnabled = true;
            this.cmbxBank.Location = new System.Drawing.Point(66, 56);
            this.cmbxBank.Name = "cmbxBank";
            this.cmbxBank.Size = new System.Drawing.Size(283, 27);
            this.cmbxBank.TabIndex = 4;
            this.cmbxBank.Enter += new System.EventHandler(this.cmbxBank_Enter);
            this.cmbxBank.Leave += new System.EventHandler(this.cmbxBank_Leave);
            // 
            // rBtnMonth
            // 
            this.rBtnMonth.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rBtnMonth.Location = new System.Drawing.Point(183, 283);
            this.rBtnMonth.Name = "rBtnMonth";
            this.rBtnMonth.Size = new System.Drawing.Size(88, 24);
            this.rBtnMonth.TabIndex = 5;
            this.rBtnMonth.TabStop = true;
            this.rBtnMonth.Text = "Месяц";
            this.rBtnMonth.UseVisualStyleBackColor = true;
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDeposit.Location = new System.Drawing.Point(183, 439);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(171, 40);
            this.btnAddDeposit.TabIndex = 8;
            this.btnAddDeposit.Text = "Добавить вклад";
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // tbxDeposit
            // 
            this.tbxDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxDeposit.Location = new System.Drawing.Point(183, 120);
            this.tbxDeposit.Name = "tbxDeposit";
            this.tbxDeposit.Size = new System.Drawing.Size(168, 27);
            this.tbxDeposit.TabIndex = 10;
            this.tbxDeposit.Enter += new System.EventHandler(this.tbxDeposit_Enter);
            this.tbxDeposit.Leave += new System.EventHandler(this.tbxDeposit_Leave);
            // 
            // labelTerm
            // 
            this.labelTerm.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTerm.Location = new System.Drawing.Point(14, 286);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(72, 23);
            this.labelTerm.TabIndex = 11;
            this.labelTerm.Text = "Срок";
            // 
            // labelBid
            // 
            this.labelBid.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBid.Location = new System.Drawing.Point(17, 347);
            this.labelBid.Name = "labelBid";
            this.labelBid.Size = new System.Drawing.Size(80, 23);
            this.labelBid.TabIndex = 12;
            this.labelBid.Text = "Ставка";
            // 
            // labelDateOpen
            // 
            this.labelDateOpen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateOpen.Location = new System.Drawing.Point(17, 410);
            this.labelDateOpen.Name = "labelDateOpen";
            this.labelDateOpen.Size = new System.Drawing.Size(139, 23);
            this.labelDateOpen.TabIndex = 13;
            this.labelDateOpen.Text = "Дата открытия";
            // 
            // tbxTerm
            // 
            this.tbxTerm.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxTerm.Location = new System.Drawing.Point(92, 282);
            this.tbxTerm.Name = "tbxTerm";
            this.tbxTerm.Size = new System.Drawing.Size(85, 27);
            this.tbxTerm.TabIndex = 14;
            this.tbxTerm.Enter += new System.EventHandler(this.tbxTerm_Enter);
            this.tbxTerm.Leave += new System.EventHandler(this.tbxTerm_Leave);
            // 
            // rBtnDays
            // 
            this.rBtnDays.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rBtnDays.Location = new System.Drawing.Point(277, 282);
            this.rBtnDays.Name = "rBtnDays";
            this.rBtnDays.Size = new System.Drawing.Size(77, 24);
            this.rBtnDays.TabIndex = 15;
            this.rBtnDays.TabStop = true;
            this.rBtnDays.Text = "День";
            this.rBtnDays.UseVisualStyleBackColor = true;
            // 
            // dtpDateOpen
            // 
            this.dtpDateOpen.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpDateOpen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpDateOpen.Location = new System.Drawing.Point(144, 406);
            this.dtpDateOpen.Name = "dtpDateOpen";
            this.dtpDateOpen.Size = new System.Drawing.Size(210, 27);
            this.dtpDateOpen.TabIndex = 16;
            // 
            // tbxBid
            // 
            this.tbxBid.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxBid.Location = new System.Drawing.Point(95, 343);
            this.tbxBid.Name = "tbxBid";
            this.tbxBid.Size = new System.Drawing.Size(85, 27);
            this.tbxBid.TabIndex = 17;
            this.tbxBid.TextChanged += new System.EventHandler(this.tbxBid_TextChanged);
            this.tbxBid.Enter += new System.EventHandler(this.tbxBid_Enter);
            this.tbxBid.Leave += new System.EventHandler(this.tbxBid_Leave);
            // 
            // labelCurrency
            // 
            this.labelCurrency.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrency.Location = new System.Drawing.Point(12, 193);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(72, 23);
            this.labelCurrency.TabIndex = 18;
            this.labelCurrency.Text = "Валюта";
            // 
            // tbxCurrency
            // 
            this.tbxCurrency.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxCurrency.Location = new System.Drawing.Point(90, 189);
            this.tbxCurrency.Name = "tbxCurrency";
            this.tbxCurrency.Size = new System.Drawing.Size(85, 27);
            this.tbxCurrency.TabIndex = 19;
            // 
            // chBxCurrency
            // 
            this.chBxCurrency.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBxCurrency.Location = new System.Drawing.Point(181, 190);
            this.chBxCurrency.Name = "chBxCurrency";
            this.chBxCurrency.Size = new System.Drawing.Size(171, 26);
            this.chBxCurrency.TabIndex = 20;
            this.chBxCurrency.Text = "Другая валюта";
            this.chBxCurrency.UseVisualStyleBackColor = true;
            this.chBxCurrency.CheckedChanged += new System.EventHandler(this.chBxCurrency_CheckedChanged);
            // 
            // cmbxCurrency
            // 
            this.cmbxCurrency.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbxCurrency.FormattingEnabled = true;
            this.cmbxCurrency.Location = new System.Drawing.Point(14, 222);
            this.cmbxCurrency.Name = "cmbxCurrency";
            this.cmbxCurrency.Size = new System.Drawing.Size(337, 27);
            this.cmbxCurrency.TabIndex = 21;
            this.cmbxCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbxCurrency_SelectedIndexChanged);
            this.cmbxCurrency.Enter += new System.EventHandler(this.cmbxCurrency_Enter);
            this.cmbxCurrency.Leave += new System.EventHandler(this.cmbxCurrency_Leave);
            // 
            // labelMandatoryBank
            // 
            this.labelMandatoryBank.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMandatoryBank.Location = new System.Drawing.Point(66, 86);
            this.labelMandatoryBank.Name = "labelMandatoryBank";
            this.labelMandatoryBank.Size = new System.Drawing.Size(283, 23);
            this.labelMandatoryBank.TabIndex = 22;
            this.labelMandatoryBank.Text = "Обязательное поле";
            // 
            // labelMandatoryDeposit
            // 
            this.labelMandatoryDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMandatoryDeposit.Location = new System.Drawing.Point(183, 150);
            this.labelMandatoryDeposit.Name = "labelMandatoryDeposit";
            this.labelMandatoryDeposit.Size = new System.Drawing.Size(173, 23);
            this.labelMandatoryDeposit.TabIndex = 23;
            this.labelMandatoryDeposit.Text = "Обязательное поле";
            // 
            // labelMandatoryCurrency
            // 
            this.labelMandatoryCurrency.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMandatoryCurrency.Location = new System.Drawing.Point(17, 252);
            this.labelMandatoryCurrency.Name = "labelMandatoryCurrency";
            this.labelMandatoryCurrency.Size = new System.Drawing.Size(283, 23);
            this.labelMandatoryCurrency.TabIndex = 24;
            this.labelMandatoryCurrency.Text = "Обязательное поле";
            // 
            // labelMandatoryTerm
            // 
            this.labelMandatoryTerm.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMandatoryTerm.Location = new System.Drawing.Point(66, 312);
            this.labelMandatoryTerm.Name = "labelMandatoryTerm";
            this.labelMandatoryTerm.Size = new System.Drawing.Size(178, 23);
            this.labelMandatoryTerm.TabIndex = 25;
            this.labelMandatoryTerm.Text = "Обязательное поле";
            // 
            // labelMandatoryBid
            // 
            this.labelMandatoryBid.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMandatoryBid.Location = new System.Drawing.Point(66, 373);
            this.labelMandatoryBid.Name = "labelMandatoryBid";
            this.labelMandatoryBid.Size = new System.Drawing.Size(178, 23);
            this.labelMandatoryBid.TabIndex = 26;
            this.labelMandatoryBid.Text = "Обязательное поле";
            // 
            // chbxCapitalization
            // 
            this.chbxCapitalization.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbxCapitalization.Location = new System.Drawing.Point(17, 447);
            this.chbxCapitalization.Name = "chbxCapitalization";
            this.chbxCapitalization.Size = new System.Drawing.Size(158, 27);
            this.chbxCapitalization.TabIndex = 27;
            this.chbxCapitalization.Text = "Капитализация";
            this.chbxCapitalization.UseVisualStyleBackColor = true;
            // 
            // AddDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 486);
            this.Controls.Add(this.chbxCapitalization);
            this.Controls.Add(this.labelMandatoryBid);
            this.Controls.Add(this.labelMandatoryTerm);
            this.Controls.Add(this.labelMandatoryCurrency);
            this.Controls.Add(this.labelMandatoryDeposit);
            this.Controls.Add(this.labelMandatoryBank);
            this.Controls.Add(this.cmbxCurrency);
            this.Controls.Add(this.chBxCurrency);
            this.Controls.Add(this.tbxCurrency);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.tbxBid);
            this.Controls.Add(this.dtpDateOpen);
            this.Controls.Add(this.rBtnDays);
            this.Controls.Add(this.tbxTerm);
            this.Controls.Add(this.labelDateOpen);
            this.Controls.Add(this.labelBid);
            this.Controls.Add(this.labelTerm);
            this.Controls.Add(this.tbxDeposit);
            this.Controls.Add(this.btnAddDeposit);
            this.Controls.Add(this.rBtnMonth);
            this.Controls.Add(this.cmbxBank);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDepositForm";
            this.Text = "Добавление вклада";
            this.Load += new System.EventHandler(this.AddDepositForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox chbxCapitalization;

        private System.Windows.Forms.Label labelMandatoryDeposit;
        private System.Windows.Forms.Label labelMandatoryCurrency;
        private System.Windows.Forms.Label labelMandatoryTerm;
        private System.Windows.Forms.Label labelMandatoryBid;

        private System.Windows.Forms.Label labelMandatoryBank;

        private System.Windows.Forms.ComboBox cmbxCurrency;

        private System.Windows.Forms.TextBox tbxCurrency;
        private System.Windows.Forms.CheckBox chBxCurrency;

        private System.Windows.Forms.TextBox tbxDeposit;
        private System.Windows.Forms.TextBox tbxBid;
        private System.Windows.Forms.RadioButton rBtnDays;
        private System.Windows.Forms.Label labelCurrency;

        private System.Windows.Forms.RadioButton rBtnMonth;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.Label labelBid;
        private System.Windows.Forms.Label labelDateOpen;
        private System.Windows.Forms.DateTimePicker dtpDateOpen;

        private System.Windows.Forms.TextBox tbxTerm;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.ComboBox cmbxBank;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnAddDeposit;

        #endregion
    }
}