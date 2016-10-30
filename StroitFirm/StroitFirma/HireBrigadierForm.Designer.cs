namespace StroitFirma
{
    partial class HireBrigadierForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.brigadierNameTB = new System.Windows.Forms.TextBox();
            this.brigadierLoginTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.brigadierPasswordTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hireBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя бригадира";
            // 
            // brigadierNameTB
            // 
            this.brigadierNameTB.Location = new System.Drawing.Point(112, 6);
            this.brigadierNameTB.Name = "brigadierNameTB";
            this.brigadierNameTB.Size = new System.Drawing.Size(160, 20);
            this.brigadierNameTB.TabIndex = 1;
            // 
            // brigadierLoginTB
            // 
            this.brigadierLoginTB.Location = new System.Drawing.Point(112, 32);
            this.brigadierLoginTB.Name = "brigadierLoginTB";
            this.brigadierLoginTB.Size = new System.Drawing.Size(160, 20);
            this.brigadierLoginTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Логин";
            // 
            // brigadierPasswordTB
            // 
            this.brigadierPasswordTB.Location = new System.Drawing.Point(112, 58);
            this.brigadierPasswordTB.Name = "brigadierPasswordTB";
            this.brigadierPasswordTB.Size = new System.Drawing.Size(160, 20);
            this.brigadierPasswordTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Пароль";
            // 
            // hireBtn
            // 
            this.hireBtn.Location = new System.Drawing.Point(112, 84);
            this.hireBtn.Name = "hireBtn";
            this.hireBtn.Size = new System.Drawing.Size(160, 23);
            this.hireBtn.TabIndex = 2;
            this.hireBtn.Text = "Нанять";
            this.hireBtn.UseVisualStyleBackColor = true;
            this.hireBtn.Click += new System.EventHandler(this.hireBtn_Click);
            // 
            // HireBrigadierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.hireBtn);
            this.Controls.Add(this.brigadierPasswordTB);
            this.Controls.Add(this.brigadierLoginTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.brigadierNameTB);
            this.Controls.Add(this.label1);
            this.Name = "HireBrigadierForm";
            this.Text = "HireBrigadierForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox brigadierNameTB;
        private System.Windows.Forms.TextBox brigadierLoginTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox brigadierPasswordTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button hireBtn;
    }
}