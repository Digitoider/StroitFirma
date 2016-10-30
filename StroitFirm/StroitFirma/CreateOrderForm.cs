using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroitFirma
{
    public partial class CreateOrderForm : Form
    {
        string login;
        public CreateOrderForm(String login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\RequestedOrders.txt", true);
            wr.WriteLine(login + "|" + richTextBox1.Text.Replace("\r\n", " "));
            wr.Flush();
            wr.Close();
            this.Dispose();
        }
    }
}
