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
    public partial class CustomerForm : Form
    {
        List<Order> ordersByLogin = new List<Order>();
        String login;
        public CustomerForm(string login)
        {
            InitializeComponent();
            this.login = login;
            AddOrdersToComboBox(login);
        }
        public void AddOrdersToComboBox(String login)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            String[] order;
            String str = rd.ReadLine();
            while(str != null)
            {
                order = str.Split('|');
                if(login == order[0])
                {
                    if(order.Length == 1)
                    {
                        return;
                    }
                    ordersByLogin.Add(new Order(order[0], Int32.Parse(order[1]), order[2], Convert.ToDateTime(order[3]),
                        float.Parse(order[4]), float.Parse(order[5]), order[6] == "true" ? true : false,
                        order[7],order[8]));
                    OrdersComboBox.Items.Add("Заказ #"+order[1]);
                }
                str = rd.ReadLine();
            }
            rd.Close();
            if (ordersByLogin.Count != 0) OrdersComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm(login);
            createOrderForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Выйти из аккаунта?","Выход", MessageBoxButtons.YesNo);
            if ( res == DialogResult.Yes)
            {
                this.Dispose();
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //inform about order
            int index = GetSelectedIndex();
            if (index != -1) ordersByLogin[index].ShowInformation();
        }
        private int GetSelectedIndex()
        {
            int index = OrdersComboBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Выберите заказ для просмотра информации о нем");
                return -1;
            }
            return index;
        }
        private void button4_Click(object sender, EventArgs e)
        { //shows material table
            int index = GetSelectedIndex();
            if (index != -1)
            {
                string path = ordersByLogin[index].GetPathToMaterialTable();
                if(path == "NOPATH")
                {
                    MessageBox.Show("Таблица материалов еще не создана");
                    return;
                }
                /*читаем данные из таблицы и отображаем их в другой форме*/
                MaterialsTableForm matTableForm = new MaterialsTableForm(path, "customer");
                matTableForm.ShowDialog();
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //shows work table
            int index = GetSelectedIndex();
            if (index != -1)
            {
                string path = ordersByLogin[index].GetPathToWorkTable();
                if (path == "NOPATH")
                {
                    MessageBox.Show("Таблица работ еще не создана");
                    return;
                }
                /*читаем данные из таблицы и отображаем их в другой форме*/
                WorkTableForm workTableForm = new WorkTableForm(path, "customer");
                workTableForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//payment
            int index = GetSelectedIndex();
            String oldValue = "";
            if (index != -1)
            {
                float i;
                try
                {
                    i = float.Parse(PayTB.Text);
                    oldValue = ordersByLogin[index].ToString();
                    ordersByLogin[index].Pay(i);
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Поле для оплаты должно содержать число");
                    return;
                }
                finally
                {
                    PayTB.Text = "Введите сумму для оплаты";
                }
            }
            else return;
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            String str = rd.ReadToEnd(); rd.Close();
            str = str.Replace(oldValue, ordersByLogin[index].ToString());
            MessageBox.Show(str);
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            wr.Write(str);
            wr.Flush();
            wr.Close();
        }
    }
}
