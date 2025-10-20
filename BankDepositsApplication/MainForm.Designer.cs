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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.btnDelDep = new System.Windows.Forms.Button();
            this.dgvPrintInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDeposit.Location = new System.Drawing.Point(1000, 388);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(150, 39);
            this.btnAddDeposit.TabIndex = 11;
            this.btnAddDeposit.Text = "Добавить вклад";
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // btnDelDep
            // 
            this.btnDelDep.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelDep.Location = new System.Drawing.Point(844, 388);
            this.btnDelDep.Name = "btnDelDep";
            this.btnDelDep.Size = new System.Drawing.Size(150, 39);
            this.btnDelDep.TabIndex = 12;
            this.btnDelDep.Text = "Закрыть вклад";
            this.btnDelDep.UseVisualStyleBackColor = true;
            this.btnDelDep.Click += new System.EventHandler(this.btnDelDep_Click);
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
            this.dgvPrintInfo.Size = new System.Drawing.Size(1137, 370);
            this.dgvPrintInfo.TabIndex = 1;
            this.dgvPrintInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrintInfo_CellMouseDoubleClick);
            this.dgvPrintInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPrintInfo_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 436);
            this.Controls.Add(this.dgvPrintInfo);
            this.Controls.Add(this.btnDelDep);
            this.Controls.Add(this.btnAddDeposit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Таблица вкладов";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelButtons;

        private System.Windows.Forms.Panel panelDataGrid;

        private System.Windows.Forms.Button btnDelDep;

        private System.Windows.Forms.Button btnAddDeposit;

        private System.Windows.Forms.DataGridView dgvPrintInfo;

        #endregion
    }
}