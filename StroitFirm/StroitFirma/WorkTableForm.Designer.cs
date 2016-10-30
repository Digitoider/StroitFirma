namespace StroitFirma
{
    partial class WorkTableForm
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
            this.KindOfWork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountWorkBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.kindOfWorkTB = new System.Windows.Forms.TextBox();
            this.kindOfWorkLbl = new System.Windows.Forms.Label();
            this.priceTB = new System.Windows.Forms.TextBox();
            this.priceLbl = new System.Windows.Forms.Label();
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
            this.KindOfWork,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(246, 219);
            this.dataGridView1.TabIndex = 0;
            // 
            // KindOfWork
            // 
            this.KindOfWork.HeaderText = "Вид работы";
            this.KindOfWork.Name = "KindOfWork";
            this.KindOfWork.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // CountWorkBtn
            // 
            this.CountWorkBtn.Location = new System.Drawing.Point(12, 227);
            this.CountWorkBtn.Name = "CountWorkBtn";
            this.CountWorkBtn.Size = new System.Drawing.Size(88, 23);
            this.CountWorkBtn.TabIndex = 1;
            this.CountWorkBtn.Text = "Подсчитать";
            this.CountWorkBtn.UseVisualStyleBackColor = true;
            this.CountWorkBtn.Click += new System.EventHandler(this.CountWorkBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(106, 315);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(141, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Visible = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // kindOfWorkTB
            // 
            this.kindOfWorkTB.Location = new System.Drawing.Point(106, 263);
            this.kindOfWorkTB.Name = "kindOfWorkTB";
            this.kindOfWorkTB.Size = new System.Drawing.Size(141, 20);
            this.kindOfWorkTB.TabIndex = 3;
            this.kindOfWorkTB.Visible = false;
            // 
            // kindOfWorkLbl
            // 
            this.kindOfWorkLbl.AutoSize = true;
            this.kindOfWorkLbl.Location = new System.Drawing.Point(12, 266);
            this.kindOfWorkLbl.Name = "kindOfWorkLbl";
            this.kindOfWorkLbl.Size = new System.Drawing.Size(69, 13);
            this.kindOfWorkLbl.TabIndex = 4;
            this.kindOfWorkLbl.Text = "Вид работы:";
            this.kindOfWorkLbl.Visible = false;
            // 
            // priceTB
            // 
            this.priceTB.Location = new System.Drawing.Point(106, 289);
            this.priceTB.Name = "priceTB";
            this.priceTB.Size = new System.Drawing.Size(141, 20);
            this.priceTB.TabIndex = 3;
            this.priceTB.Visible = false;
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(12, 292);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(36, 13);
            this.priceLbl.TabIndex = 4;
            this.priceLbl.Text = "Цена:";
            this.priceLbl.Visible = false;
            // 
            // WorkTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 343);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.kindOfWorkLbl);
            this.Controls.Add(this.priceTB);
            this.Controls.Add(this.kindOfWorkTB);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.CountWorkBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "WorkTableForm";
            this.Text = "WorkTableForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkTableForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KindOfWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button CountWorkBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox kindOfWorkTB;
        private System.Windows.Forms.Label kindOfWorkLbl;
        private System.Windows.Forms.TextBox priceTB;
        private System.Windows.Forms.Label priceLbl;
    }
}