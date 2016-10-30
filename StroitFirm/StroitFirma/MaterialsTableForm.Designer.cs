namespace StroitFirma
{
    partial class MaterialsTableForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceForOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountBtn = new System.Windows.Forms.Button();
            this.increaseBtn = new System.Windows.Forms.Button();
            this.amountTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialName,
            this.Amount,
            this.SpentAmount,
            this.PriceForOne});
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(439, 259);
            this.dataGridView1.TabIndex = 0;
            // 
            // MaterialName
            // 
            this.MaterialName.HeaderText = "Наименование";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // SpentAmount
            // 
            this.SpentAmount.HeaderText = "Использовано";
            this.SpentAmount.Name = "SpentAmount";
            this.SpentAmount.ReadOnly = true;
            // 
            // PriceForOne
            // 
            this.PriceForOne.HeaderText = "Цена за единицу";
            this.PriceForOne.Name = "PriceForOne";
            this.PriceForOne.ReadOnly = true;
            // 
            // CountBtn
            // 
            this.CountBtn.Location = new System.Drawing.Point(5, 267);
            this.CountBtn.Name = "CountBtn";
            this.CountBtn.Size = new System.Drawing.Size(108, 23);
            this.CountBtn.TabIndex = 1;
            this.CountBtn.Text = "Посчитать сумму";
            this.CountBtn.UseVisualStyleBackColor = true;
            this.CountBtn.Click += new System.EventHandler(this.CountBtn_Click);
            // 
            // increaseBtn
            // 
            this.increaseBtn.Location = new System.Drawing.Point(119, 267);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(280, 23);
            this.increaseBtn.TabIndex = 2;
            this.increaseBtn.Text = "Увеличить колво использованного материала  на:";
            this.increaseBtn.UseVisualStyleBackColor = true;
            this.increaseBtn.Visible = false;
            this.increaseBtn.Click += new System.EventHandler(this.increaseBtn_Click);
            // 
            // amountTB
            // 
            this.amountTB.Location = new System.Drawing.Point(405, 269);
            this.amountTB.Name = "amountTB";
            this.amountTB.Size = new System.Drawing.Size(35, 20);
            this.amountTB.TabIndex = 3;
            this.amountTB.Visible = false;
            // 
            // MaterialsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 311);
            this.Controls.Add(this.amountTB);
            this.Controls.Add(this.increaseBtn);
            this.Controls.Add(this.CountBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MaterialsTableForm";
            this.Text = "MaterialsTableForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialsTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CountBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceForOne;
        private System.Windows.Forms.Button increaseBtn;
        private System.Windows.Forms.TextBox amountTB;
    }
}