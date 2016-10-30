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
    public partial class HireBrigadierForm : Form
    {
        List<String> bregadierslist = new List<string>();
        public HireBrigadierForm()
        {
            InitializeComponent();
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            string str = rd.ReadLine();
            string[] values;
            while (str != null)
            {
                values = str.Split('|');
                bregadierslist.Add(values[1]);
                str = rd.ReadLine();
            }
            rd.Close();
        }
        private void Hire()
        {
            String name = brigadierNameTB.Text.Trim(),
                 login = brigadierLoginTB.Text.Trim(),
                 password = brigadierPasswordTB.Text.Trim();
            if (name.Length == 0 || login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            foreach (string s in bregadierslist)
            {
                if (s == login)
                {
                    MessageBox.Show("Такой логин уже существует");
                    return;
                }
            }
            if (login == "Director" || LogInForm.CheckUser(login))
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\BrigadiersFile.txt", true);
            wr.WriteLine(name + "|" + login + "|" + password + "|false");
            wr.Flush();
            wr.Close();
            SetBrigadierForm.bregadier = login;
            this.Close();
        }
        private void hireBtn_Click(object sender, EventArgs e)
        {
            Hire();
        }
    }
}
