namespace StroitFirma
{
    partial class MainDirectorForm
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
            this.openAp = new System.Windows.Forms.Button();
            this.finishedCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showInformationBtn = new System.Windows.Forms.Button();
            this.approveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openAp
            // 
            this.openAp.Location = new System.Drawing.Point(12, 12);
            this.openAp.Name = "openAp";
            this.openAp.Size = new System.Drawing.Size(235, 23);
            this.openAp.TabIndex = 0;
            this.openAp.Text = "Открыть форму подтверждения заказов";
            this.openAp.UseVisualStyleBackColor = true;
            this.openAp.Click += new System.EventHandler(this.openAp_Click);
            // 
            // finishedCB
            // 
            this.finishedCB.FormattingEnabled = true;
            this.finishedCB.Location = new System.Drawing.Point(12, 71);
            this.finishedCB.Name = "finishedCB";
            this.finishedCB.Size = new System.Drawing.Size(151, 21);
            this.finishedCB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Завершенные:";
            // 
            // showInformationBtn
            // 
            this.showInformationBtn.Location = new System.Drawing.Point(12, 98);
            this.showInformationBtn.Name = "showInformationBtn";
            this.showInformationBtn.Size = new System.Drawing.Size(151, 23);
            this.showInformationBtn.TabIndex = 3;
            this.showInformationBtn.Text = "Просмотр информации";
            this.showInformationBtn.UseVisualStyleBackColor = true;
            this.showInformationBtn.Click += new System.EventHandler(this.showInformationBtn_Click);
            // 
            // approveBtn
            // 
            this.approveBtn.Location = new System.Drawing.Point(12, 127);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(151, 23);
            this.approveBtn.TabIndex = 4;
            this.approveBtn.Text = "Подтвердить завершение";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // MainDirectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.approveBtn);
            this.Controls.Add(this.showInformationBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishedCB);
            this.Controls.Add(this.openAp);
            this.Name = "MainDirectorForm";
            this.Text = "MainDirectorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openAp;
        private System.Windows.Forms.ComboBox finishedCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showInformationBtn;
        private System.Windows.Forms.Button approveBtn;
    }
}