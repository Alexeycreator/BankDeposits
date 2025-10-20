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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.dgvPrintInfo = new System.Windows.Forms.DataGridView();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).BeginInit();
            this.panelDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDeposit.Location = new System.Drawing.Point(849, 14);
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
            this.btnDelDep.Location = new System.Drawing.Point(693, 14);
            this.btnDelDep.Name = "btnDelDep";
            this.btnDelDep.Size = new System.Drawing.Size(150, 39);
            this.btnDelDep.TabIndex = 12;
            this.btnDelDep.Text = "Закрыть вклад";
            this.btnDelDep.UseVisualStyleBackColor = true;
            this.btnDelDep.Click += new System.EventHandler(this.btnDelDep_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnDelDep);
            this.panelButtons.Controls.Add(this.btnAddDeposit);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 417);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1218, 56);
            this.panelButtons.TabIndex = 13;
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
            this.dgvPrintInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvPrintInfo.Name = "dgvPrintInfo";
            this.dgvPrintInfo.RowTemplate.Height = 24;
            this.dgvPrintInfo.Size = new System.Drawing.Size(1218, 417);
            this.dgvPrintInfo.TabIndex = 1;
            this.dgvPrintInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrintInfo_CellMouseDoubleClick);
            this.dgvPrintInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPrintInfo_MouseClick);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Controls.Add(this.dgvPrintInfo);
            this.panelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGrid.Location = new System.Drawing.Point(0, 0);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1218, 417);
            this.panelDataGrid.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1218, 473);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintInfo)).EndInit();
            this.panelDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelDataGrid;

        private System.Windows.Forms.Panel panelButtons;
        
        private System.Windows.Forms.Button btnDelDep;

        private System.Windows.Forms.Button btnAddDeposit;

        private System.Windows.Forms.DataGridView dgvPrintInfo;

        #endregion
    }
}