namespace BankDepositsApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrintInfo = new System.Windows.Forms.DataGridView();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrintInfo
            // 
            this.dgvPrintInfo.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvPrintInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrintInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintInfo.Location = new System.Drawing.Point(12, 12);
            this.dgvPrintInfo.Name = "dgvPrintInfo";
            this.dgvPrintInfo.RowTemplate.Height = 24;
            this.dgvPrintInfo.Size = new System.Drawing.Size(976, 370);
            this.dgvPrintInfo.TabIndex = 1;
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDeposit.Location = new System.Drawing.Point(838, 388);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(150, 39);
            this.btnAddDeposit.TabIndex = 11;
            this.btnAddDeposit.Text = "Добавить вклад";
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 439);
            this.Controls.Add(this.btnAddDeposit);
            this.Controls.Add(this.dgvPrintInfo);
            this.Name = "MainForm";
            this.Text = "Таблица вкладов";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnAddDeposit;

        private System.Windows.Forms.DataGridView dgvPrintInfo;

        #endregion
    }
}