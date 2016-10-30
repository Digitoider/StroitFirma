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
    
    public partial class MaterialsTableForm : Form
    {
        private string bregLogin;
        private double finalPrice = 0;
        private String person, path;
        private bool saved = true;
        public MaterialsTableForm(String path, String person, String login = "")
        {
            InitializeComponent();
            bregLogin = login;
            if (path == "NOPATH")
            {
                MessageBox.Show("Не могу найти файл");
                this.Close();
            }
            this.person = person;
            if (person == "bregadier")
            {
                increaseBtn.Visible = true;
                amountTB.Visible = true;
            }
            this.path = path;
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            //MessageBox.Show(path);
            
            StreamReader rd = new StreamReader(path);
            object[] elements = new object[4];
            String str = rd.ReadLine();
            while(str != null)
            {
                elements = str.Split('|');
                dataGridView1.Rows.Add(elements);
                str = rd.ReadLine();
            }
            rd.Close();
        }
        private void CountPrice()
        {
            float sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //MessageBox.Show(row.Cells[1].ValueType.ToString()+"<-=->"+row.Cells[1].Value);
                sum += float.Parse(row.Cells[2].Value.ToString()) * float.Parse(row.Cells[3].Value.ToString());
            }
            MessageBox.Show("Цена на все материалы: " + sum);
        }
        private void SetSpentAmount()
        {
            int amount;
            try
            {
                amount = Int32.Parse(amountTB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Число введено некорректно");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                object[] items = new object[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    items[i] = row.Cells[i].Value;
                }
                int cell1, cell2;
                string item1 = Convert.ToString(items[1]);
                string item2 = Convert.ToString(items[2]);
                MessageBox.Show(">" + item2 + "<|>" + item1 + "<");
                if (Int32.TryParse(item2, out cell2) && Int32.TryParse(item1, out cell1))
                {
                    if (cell2 + amount > cell1)
                    {
                        DialogResult res = MessageBox.Show("Количество материалов меньше использованного. Заполнить до максимума?", "", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            items[2] = items[1];
                            finalPrice += (cell1 - cell2) * Convert.ToDouble(items[3]);
                        }
                        else continue;
                    }
                    else {
                        items[2] = (object)(cell2 + amount);
                        finalPrice += amount * Convert.ToDouble(items[3]);
                    }
                }
                else {
                    MessageBox.Show("Значение в текстовом поле введено неверно");
                    continue;
                }
                int index = dataGridView1.Rows.IndexOf(row);
                dataGridView1.Rows.Remove(row);
                dataGridView1.Rows.Insert(index, items);
                saved = false;
            }
        }
        private void CountBtn_Click(object sender, EventArgs e)
        {
            CountPrice();
        }

        private void increaseBtn_Click(object sender, EventArgs e)
        {
            SetSpentAmount();
        }
        private void MaterialsTableForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void SaveToFile()
        {
            string str;
            StreamWriter wr = new StreamWriter(path);
            foreach(DataGridViewRow row in dataGridView1.Rows)
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
                if (order[2] == bregLogin && order[7] == path)
                    break;
                str = rd.ReadLine();
            }
            rd.Close();
            rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            string data = rd.ReadToEnd();rd.Close();
            string s = order[5];
            order[5] = (Convert.ToDouble(order[5]) + finalPrice).ToString("F");
            Order order1 = new Order(order[0], Int32.Parse(order[1]), order[2], Convert.ToDateTime(order[3]),
                        float.Parse(order[4]), float.Parse(order[5]), order[6] == "true" ? true : false,
                        order[7], order[8]);
            wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            wr.Write(data.Replace(str, order1.ToString()));
            wr.Flush(); wr.Close();
        }
    }
}
