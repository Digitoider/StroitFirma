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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            loginTB.Text = "Director";
            passwordTB.Text = "pass";
            button1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(loginTB.Text.Length == 0 || passwordTB.Text.Length == 0)
            {
                MessageBox.Show("Поля должны быть заполнены");
                return;
            }
            if (loginTB.Text == "Director" && passwordTB.Text == "pass")
            {
                MainDirectorForm directorForm = new MainDirectorForm();
                this.Dispose();
                directorForm.ShowDialog();
            }
            else if (LogInForm.CheckUser(loginTB.Text, passwordTB.Text, @"D:\DataForTSPP\BrigadiersFile.txt"))
            {
                BrigadierForm brigadierForm = new BrigadierForm(loginTB.Text);
                //this.Dispose();
                brigadierForm.ShowDialog();
            }
            else if (!LogInForm.CheckUser(loginTB.Text, passwordTB.Text))
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            else {
                this.Close();

                /*открыть форму заказчика по логину и паролю*/
                CustomerForm customerForm = new CustomerForm(loginTB.Text);
                customerForm.ShowDialog();
            }
        }
        
        public static bool CheckUser(String login,String password = "", string path = @"D:\DataForTSPP\UsersFile.txt")
        {
            StreamReader rd = new StreamReader(path);

            String[] name_log_pass;
            String str = rd.ReadLine();
            if (password != "")
            {
                while (str != null)
                {
                    name_log_pass = str.Split('|');
                    if (login == name_log_pass[1] && password == name_log_pass[2])
                    {
                        rd.Close();
                        return true;
                    }
                    str = rd.ReadLine();
                }
            }
            else
            {
                while (str != null)
                {
                    name_log_pass = str.Split('|');
                    if (login == name_log_pass[1])
                    {
                        rd.Close();
                        return true;
                    }
                    str = rd.ReadLine();
                }
            }
            rd.Close();
            return false;
        }
    }
}
