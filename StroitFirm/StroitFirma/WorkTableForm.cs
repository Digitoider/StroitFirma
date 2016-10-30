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
    public partial class WorkTableForm : Form
    {
        String person;
        String path;
        private bool saved = true;
        private string bregLogin;
        private double finalPrice = 0;

        public WorkTableForm(String path, String person, string login = "")
        {
            InitializeComponent();
            bregLogin = login;
            if (path == "NOPATH")
            {
                MessageBox.Show("Не могу найти файл");
                this.Close();
            }
            this.path = path;
            this.person = person;
            if (person == "bregadier")
            {
                kindOfWorkLbl.Visible = true;
                kindOfWorkTB.Visible = true;
                priceLbl.Visible = true;
                priceTB.Visible = true;
                addBtn.Visible = true;
                this.Height = 382;
            }
            else this.Height = 300;
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            StreamReader rd = new StreamReader(path);
            object[] elements = new object[4];
            String str = rd.ReadLine();
            while (str != null)
            {
                elements = str.Split('|');
                dataGridView1.Rows.Add(elements);
                str = rd.ReadLine();
            }
            rd.Close();
        }
        private void CountWork()
        {
            float sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                sum += float.Parse(row.Cells[1].Value.ToString());
            MessageBox.Show("Цена на все работы: " + sum);
        }
        private void AddWork()
        {
            if (priceTB.Text.Length == 0 || kindOfWorkTB.Text.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            float price;
            if (!float.TryParse(priceTB.Text.Replace('.', ','), out price))
            {
                MessageBox.Show(@"В поле 'цена' должно быть число");
                return;
            }
            finalPrice += price;
            dataGridView1.Rows.Add(kindOfWorkTB.Text, price);
            saved = false;
        }
        private void CountWorkBtn_Click(object sender, EventArgs e)
        {
            CountWork();
        }
        
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddWork();
        }
        private void SaveToFile()
        {
            string str;
            StreamWriter wr = new StreamWriter(path);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                str = "";
                object[] items = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    items[i] = row.Cells[i].Value;
                    str += items[i] + "|";
                }
                wr.WriteLine(str.Substring(0, str.Length - 1));
            }
            wr.Flush();
            wr.Close();
            if (bregLogin.Length == 0) return;
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            str = rd.ReadLine();
            string[] order = new String[10];
            while (str != null)
            {
                order = str.Split('|');
                if (order[2] == bregLogin && order[8] == path)
                    break;
                str = rd.ReadLine();
            }
            rd.Close();
            rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            string data = rd.ReadToEnd(); rd.Close();
            string s = order[5];
            order[5] = (Convert.ToDouble(order[5]) + finalPrice).ToString("F");
            Order order1 = new Order(order[0], Int32.Parse(order[1]), order[2], Convert.ToDateTime(order[3]),
                        float.Parse(order[4]), float.Parse(order[5]), order[6] == "true" ? true : false,
                        order[7], order[8]);
            wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            wr.Write(data.Replace(str, order1.ToString()));
            wr.Flush(); wr.Close();
        }
        private void WorkTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult res = MessageBox.Show("Сохранить значения в файл?", "Сохранение", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    SaveToFile();
                }
            }
        }
    }
}
