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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTB.Text.Length == 0 || loginTB.Text.Length == 0 || passwordTB.Text.Length == 0)
            {
                MessageBox.Show("Поля должны быть заполнены!");
                return;
            }
            if(loginTB.Text == "Director" || LogInForm.CheckUser(loginTB.Text) || CheckBregadier(loginTB.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            /*Регистрация закончена успешно*/
            AddUser(nameTB.Text, loginTB.Text, passwordTB.Text);
            MessageBox.Show("Регистрация прошла успешно");
            this.Close();
        }

        private bool CheckBregadier(string login)
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            String str = rd.ReadLine();
            String[] strs;
            while (str != null)
            {
                strs = str.Split('|');
                if (login == strs[1])
                {
                    rd.Close();
                    return true;
                }
                str = rd.ReadLine();
            }
            rd.Close();
            return false;
        }

        public void AddUser(string name, string login, string password)
        {
            //name|login|password|amount of created orders
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\UsersFile.txt", true);
            wr.WriteLine("{0}|{1}|{2}|0", name, login, password);
            wr.Flush();
            wr.Close();
            /*wr = new StreamWriter(@"D:\DataForTSPP\OrdersTableByLogin.txt", true);
            wr.WriteLine(login + "|");
            wr.Flush();
            wr.Close();*/
        }
    }
}
