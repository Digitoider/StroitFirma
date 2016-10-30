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
    public partial class MainDirectorForm : Form
    {
        List<String> finishedOrders = new List<string>(); 
        public MainDirectorForm()
        {
            InitializeComponent();
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\FinishedOrders.txt");
            String str = rd.ReadLine();
            while (str != null)
            {
                finishedCB.Items.Add(str);
                str = rd.ReadLine();
            }
            rd.Close();
            if (finishedCB.Items.Count != 0) finishedCB.SelectedIndex = 0;
        }
        private void openAp_Click(object sender, EventArgs e)
        {
            DirectorForm form = new DirectorForm();
            form.ShowDialog();
        }
        private void ShowInformation()
        {
            int index = finishedCB.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Выделите элемент");
                return;
            }
            String[] logins = ((String)finishedCB.SelectedItem).Split('|');
            Order order;
            try
            {
                order = FindOrderBy(logins[0], logins[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            order.ShowInformation();
        }
        private void showInformationBtn_Click(object sender, EventArgs e)
        {
            ShowInformation();
        }

        private Order FindOrderBy(string bregadierLogin, string userLogin)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            String[] order;
            String str = rd.ReadLine();
            while (str != null)
            {
                order = str.Split('|');
                if (userLogin == order[0] && bregadierLogin == order[2] && order[6] == "false")
                {
                    rd.Close();
                    return new Order(order[0], Int32.Parse(order[1]), order[2], Convert.ToDateTime(order[3]),
                        float.Parse(order[4]), float.Parse(order[5]), order[6] == "true" ? true : false,
                        order[7], order[8]);
                }
                str = rd.ReadLine();
            }
            rd.Close();
            throw new Exception("Не получается найти заказ");
        }
        private void Approve()
        {
            int index = finishedCB.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Выделите элемент");
                return;
            }
            String[] logins = ((String)finishedCB.SelectedItem).Split('|');
            Order order;
            try
            {
                order = FindOrderBy(logins[0], logins[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (order.HowMuchToPay() > 0.001)
            {
                DialogResult res = MessageBox.Show("Проект еще не оплачен, к оплате " + order.HowMuchToPay() + ". Завершить строительство?",
                    "Завершить?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    Approve(order, index);
                return;
            }
            Approve(order, index);
        }
        private void approveBtn_Click(object sender, EventArgs e)
        {
            Approve();
        }
        private void Approve(Order order, int index)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            String str = rd.ReadToEnd(); rd.Close();
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            String oldValue = order.ToString();
            order.buildingComplete = true;
            wr.Write(str.Replace(oldValue, order.ToString()));
            wr.Flush();
            wr.Close();
            MessageBox.Show("Строительство для " + order.owner + " завершено");
            rd = new StreamReader(@"D:\DataForTSPP\FinishedOrders.txt");
            str = rd.ReadToEnd();rd.Close();
            wr = new StreamWriter(@"D:\DataForTSPP\FinishedOrders.txt");
            oldValue = (string)finishedCB.SelectedItem;
            wr.Write(str.Replace(oldValue + "\r\n", "")); wr.Flush(); wr.Close();
            finishedCB.Items.RemoveAt(index);
            if (finishedCB.Items.Count > 0) finishedCB.SelectedIndex = 0;
        }
    }
}
