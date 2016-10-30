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
    public partial class DirectorForm : Form
    {
        List<RequestedOrder> requstedOrders = new List<RequestedOrder>();
        internal static string selectedBregadier;

        public DirectorForm()
        {
            InitializeComponent();
            FinishAddMaterialBtn.Visible = false;
            AddMaterialBtn.Enabled = false;
            dayTB.Enabled = false;
            monthTB.Enabled = false;
            yearTB.Enabled = false;
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\RequestedOrders.txt");
            String[] orders;
            String str = rd.ReadLine();
            while(str != null)
            {
               // MessageBox.Show(str);

                orders = str.Split('|');
                if (orders.Length < 2) break;
                requstedOrders.Add(new RequestedOrder(orders[0], orders[1]));//тут ошибка с индексом
                OrdersComboBox.Items.Add(orders[0]);
                str = rd.ReadLine();
            }
            if (requstedOrders.Count != 0) OrdersComboBox.SelectedIndex = 0;
            rd.Close();
        }

        private void OrdersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CheckSelectedIndex();
            if (index != -1)
                if (descriptionRTB.Text == "") descriptionRTB.Text = "Нет описания";
                else descriptionRTB.Text = requstedOrders[index].GetDescription();
        }

        private int CheckSelectedIndex()
        {
            int index = OrdersComboBox.SelectedIndex;
            if (index == -1)
                MessageBox.Show("Выделите заказ");
            return index;
        }
        private void AddMaterial()
        {
            if (matNameTB.Text == "" || matAmountTB.Text == "" || matPriceForOne.Text == "")
            {
                if (OrdersComboBox.SelectedIndex == -1) MessageBox.Show("Выделите заказ");
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            String login = requstedOrders[OrdersComboBox.SelectedIndex].GetLogin();
            int amountOfOrders = AmountOfOrdersBy(login);
            String path = @"D:\DataForTSPP\MaterialTable_" + login + "_" + (amountOfOrders + 1).ToString() + ".txt";
            //ReplaceInUsersFile(login, amountOfOrders+1);
            StreamWriter wr = new StreamWriter(path, true);
            wr.WriteLine("{0}|{1}|0|{2}", matNameTB.Text, matAmountTB.Text, matPriceForOne.Text.Replace('.', ','));
            wr.Flush();
            wr.Close();
            requstedOrders[OrdersComboBox.SelectedIndex].SetPathToMaterialTable(path);
            requstedOrders[OrdersComboBox.SelectedIndex].SetPathToWorkTable(path.Replace("MaterialTable", "WorkTable"));
            FinishAddMaterialBtn.Visible = true;
        }
        private void AddMaterialBtn_Click(object sender, EventArgs e)
        {
            AddMaterial();
        }

        private void ReplaceInUsersFile(string login, int amountOfOrders)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\UsersFile.txt");
            String[] users;
            String oldValue="", newValue="";
            String str = rd.ReadLine();
            while (str != null)
            {
                users = str.Split('|');
                if (login == users[1])
                {
                    oldValue = String.Join("|", users);
                    users[3] = amountOfOrders.ToString();
                    newValue = String.Join("|", users);
                    rd.Close();
                    break;
                }
                str = rd.ReadLine();
            }
            rd = new StreamReader(@"D:\DataForTSPP\UsersFile.txt");
            str = rd.ReadToEnd(); rd.Close();
            
            str = str.Replace(oldValue, newValue);
            //MessageBox.Show(str);
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\UsersFile.txt");
            wr.Write(str);
            wr.Flush();
            wr.Close();
        }

        private int AmountOfOrdersBy(string login)//количество заказов по логину
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\UsersFile.txt");
            String[] users;
            String str = rd.ReadLine();
            while(str != null)
            {
                users = str.Split('|');
                if (login == users[1])
                {
                    rd.Close();
                    return Int32.Parse(users[3]);
                }
                str = rd.ReadLine();
            }
            rd.Close();
            return -1;
        }
        private void Approve()
        {
            int index = OrdersComboBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Выделите элемент");
                return;
            }
            SetBrigadierForm setBrigadierForm = new SetBrigadierForm();
            setBrigadierForm.ShowDialog();
            String brigadier = setBrigadierForm.GetBrigadier();
            if (brigadier == "") return;
            else
            {

                StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
                String str = rd.ReadToEnd(); rd.Close();
                //MessageBox.Show(str);
                rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
                String oldValue = rd.ReadLine();
                String[] values;
                while (oldValue != null)
                {
                    values = oldValue.Split('|');
                    if (values[1] == brigadier)
                        break;
                    oldValue = rd.ReadLine();
                }
                rd.Close();
                str = str.Replace(oldValue, oldValue.Replace("false", "true"));
                StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\BrigadiersFile.txt");
                wr.Write(str); wr.Flush(); wr.Close();
            }
            setBrigadierForm.Dispose();
            approveBtn.Enabled = false;
            OrdersComboBox.Enabled = false;
            AddMaterialBtn.Enabled = true;
            dayTB.Enabled = true;
            monthTB.Enabled = true;
            yearTB.Enabled = true;

        }
        private void approveBtn_Click(object sender, EventArgs e)
        {
            Approve();
        }
        private void FinishAddingMaterial()
        {
            ///
            /// Here I should ADD string to file OrdersTableByLogin.txt,
            /// where I should change pathToMaterialTable
            ///
            int day, month, year;
            try
            {
                month = Int32.Parse(monthTB.Text);
                if (month > 12 || month < 1)
                {
                    MessageBox.Show("Месяц должен находится в диапазоне от 1 до 12");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Месяц должен представляться числовым значением");
                return;
            }
            try
            {
                day = Int32.Parse(dayTB.Text);
                if (day > 28 || day < 1)
                {
                    MessageBox.Show("День должен находится в диапазоне от 1 до 28");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Месяц должен представляться числовым значением");
                return;
            }
            try
            {
                year = Int32.Parse(yearTB.Text);
                int t = DateTime.Now.Year;
                if (year < t)
                {
                    MessageBox.Show("Проект не может быть окончен в прошлом");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Год должен представляться числовым значением");
                return;
            }
            String date = day + "." + month + "." + year + " " + "0:00:00";
            try
            {
                DateTime d = DateTime.Parse(date);
                if (d < DateTime.Now)
                {
                    MessageBox.Show("Проект не может быть завершен в прошлом");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не получается преобразовать дату");
                return;
            }


            approveBtn.Enabled = true;
            OrdersComboBox.Enabled = true;
            AddMaterialBtn.Enabled = false;
            FinishAddMaterialBtn.Visible = false;

            String login = requstedOrders[OrdersComboBox.SelectedIndex].GetLogin();
            ReplaceInUsersFile(login, AmountOfOrdersBy(login) + 1);
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\RequestedOrders.txt");
            String str = rd.ReadToEnd(); rd.Close();
            String oldValue = requstedOrders[OrdersComboBox.SelectedIndex].ToString();
            str = str.Replace(oldValue + "\r\n", "");
            //str = str.Replace("\r\n\r\n", "\r\n");//This is not correct!!!
            //MessageBox.Show(str);
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\RequestedOrders.txt");
            wr.Write(str);
            wr.Flush();
            wr.Close();

            wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt", true);
            string item = login;
            item += "|" + AmountOfOrdersBy(login).ToString();
            item += "|" + selectedBregadier;
            item += "|" + date + "|0|0|false";
            item += "|" + requstedOrders[OrdersComboBox.SelectedIndex].GetPathToMaterialTable();
            item += "|" + requstedOrders[OrdersComboBox.SelectedIndex].GetPathToWorkTable();
            wr.WriteLine(item); wr.Flush(); wr.Close();

            File.Create(requstedOrders[OrdersComboBox.SelectedIndex].GetPathToWorkTable());
            requstedOrders.RemoveAt(OrdersComboBox.SelectedIndex);
            OrdersComboBox.Items.RemoveAt(OrdersComboBox.SelectedIndex);

        }
        private void FinishAddMaterialBtn_Click(object sender, EventArgs e)
        {
            FinishAddingMaterial();
        }

        /*private String GetNameFromUsersTableBy(String login)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\UsersFile.txt");
            String[] users;
            String str = rd.ReadLine();
            while (str != null)
            {
                users = str.Split('|');
                if (login == users[1])
                {
                    rd.Close();
                    return users[0];
                }
                str = rd.ReadLine();
            }
            rd.Close();//suppose, that this branch will be never executed
            return "NoUserFoundWithSuchLogin";
        }*/

        private void DirectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!approveBtn.Enabled)
            {
                MessageBox.Show("Вы должны завершить подтверждение заказа");
                e.Cancel = true;
            }
        }
    }
    public class RequestedOrder
    {
        String login, description, pathToMaterialTable, pathToWorkTable;
        public String GetDescription()
        {
            return description;
        }

        internal string GetLogin()
        {
            return login;
        }
        public override string ToString()
        {
            return login + "|" + description;
        }

        internal void SetPathToMaterialTable(string path)
        {
            if(pathToMaterialTable == "NOPATH")pathToMaterialTable = path;   
        }
        internal void SetPathToWorkTable(string path)
        {
            if (pathToWorkTable == "NOPATH") pathToWorkTable = path;
        }
        internal string GetPathToMaterialTable()
        {
            return pathToMaterialTable;
        }
        internal string GetPathToWorkTable()
        {
            return pathToWorkTable;
        }
        public RequestedOrder(String login, String description)
        {
            this.login = login;
            this.description = description;
            pathToMaterialTable = pathToWorkTable = "NOPATH"; 
        }
    }
}
