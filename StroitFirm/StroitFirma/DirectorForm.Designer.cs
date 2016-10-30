namespace StroitFirma
{
    partial class DirectorForm
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
            this.OrdersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionRTB = new System.Windows.Forms.RichTextBox();
            this.matNameTB = new System.Windows.Forms.TextBox();
            this.approveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matAmountTB = new System.Windows.Forms.TextBox();
            this.matPriceForOne = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddMaterialBtn = new System.Windows.Forms.Button();
            this.FinishAddMaterialBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dayTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.monthTB = new System.Windows.Forms.TextBox();
            this.yearTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OrdersComboBox
            // 
            this.OrdersComboBox.FormattingEnabled = true;
            this.OrdersComboBox.Location = new System.Drawing.Point(12, 27);
            this.OrdersComboBox.Name = "OrdersComboBox";
            this.OrdersComboBox.Size = new System.Drawing.Size(121, 21);
            this.OrdersComboBox.TabIndex = 0;
            this.OrdersComboBox.SelectedIndexChanged += new System.EventHandler(this.OrdersComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поступившие заказы от";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание";
            // 
            // descriptionRTB
            // 
            this.descriptionRTB.Location = new System.Drawing.Point(12, 77);
            this.descriptionRTB.Name = "descriptionRTB";
            this.descriptionRTB.Size = new System.Drawing.Size(165, 96);
            this.descriptionRTB.TabIndex = 2;
            this.descriptionRTB.Text = "";
            // 
            // matNameTB
            // 
            this.matNameTB.Location = new System.Drawing.Point(330, 9);
            this.matNameTB.Name = "matNameTB";
            this.matNameTB.Size = new System.Drawing.Size(155, 20);
            this.matNameTB.TabIndex = 3;
            // 
            // approveBtn
            // 
            this.approveBtn.Location = new System.Drawing.Point(12, 179);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(165, 23);
            this.approveBtn.TabIndex = 4;
            this.approveBtn.Text = "Подтвердить заказ";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Наименование";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Количество";
            // 
            // matAmountTB
            // 
            this.matAmountTB.Location = new System.Drawing.Point(330, 35);
            this.matAmountTB.Name = "matAmountTB";
            this.matAmountTB.Size = new System.Drawing.Size(155, 20);
            this.matAmountTB.TabIndex = 3;
            // 
            // matPriceForOne
            // 
            this.matPriceForOne.Location = new System.Drawing.Point(330, 61);
            this.matPriceForOne.Name = "matPriceForOne";
            this.matPriceForOne.Size = new System.Drawing.Size(155, 20);
            this.matPriceForOne.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Цена за единицу";
            // 
            // AddMaterialBtn
            // 
            this.AddMaterialBtn.Location = new System.Drawing.Point(330, 88);
            this.AddMaterialBtn.Name = "AddMaterialBtn";
            this.AddMaterialBtn.Size = new System.Drawing.Size(155, 20);
            this.AddMaterialBtn.TabIndex = 4;
            this.AddMaterialBtn.Text = "Добавить";
            this.AddMaterialBtn.UseVisualStyleBackColor = true;
            this.AddMaterialBtn.Click += new System.EventHandler(this.AddMaterialBtn_Click);
            // 
            // FinishAddMaterialBtn
            // 
            this.FinishAddMaterialBtn.Location = new System.Drawing.Point(330, 191);
            this.FinishAddMaterialBtn.Name = "FinishAddMaterialBtn";
            this.FinishAddMaterialBtn.Size = new System.Drawing.Size(153, 23);
            this.FinishAddMaterialBtn.TabIndex = 6;
            this.FinishAddMaterialBtn.Text = "Завершить";
            this.FinishAddMaterialBtn.UseVisualStyleBackColor = true;
            this.FinishAddMaterialBtn.Click += new System.EventHandler(this.FinishAddMaterialBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата завершения строительства";
            // 
            // dayTB
            // 
            this.dayTB.Location = new System.Drawing.Point(226, 153);
            this.dayTB.Name = "dayTB";
            this.dayTB.Size = new System.Drawing.Size(31, 20);
            this.dayTB.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "День";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Месяц";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Год";
            // 
            // monthTB
            // 
            this.monthTB.Location = new System.Drawing.Point(266, 153);
            this.monthTB.Name = "monthTB";
            this.monthTB.Size = new System.Drawing.Size(31, 20);
            this.monthTB.TabIndex = 3;
            // 
            // yearTB
            // 
            this.yearTB.Location = new System.Drawing.Point(312, 153);
            this.yearTB.Name = "yearTB";
            this.yearTB.Size = new System.Drawing.Size(71, 20);
            this.yearTB.TabIndex = 3;
            // 
            // DirectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 261);
            this.Controls.Add(this.FinishAddMaterialBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddMaterialBtn);
            this.Controls.Add(this.approveBtn);
            this.Controls.Add(this.yearTB);
            this.Controls.Add(this.monthTB);
            this.Controls.Add(this.dayTB);
            this.Controls.Add(this.matPriceForOne);
            this.Controls.Add(this.matAmountTB);
            this.Controls.Add(this.matNameTB);
            this.Controls.Add(this.descriptionRTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrdersComboBox);
            this.Name = "DirectorForm";
            this.Text = "DirectorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OrdersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox descriptionRTB;
        private System.Windows.Forms.TextBox matNameTB;
        private System.Windows.Forms.Button approveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox matAmountTB;
        private System.Windows.Forms.TextBox matPriceForOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddMaterialBtn;
        private System.Windows.Forms.Button FinishAddMaterialBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dayTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox monthTB;
        private System.Windows.Forms.TextBox yearTB;
    }
}