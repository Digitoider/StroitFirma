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
    public partial class BrigadierForm : Form
    {
        private string bregadierLogin;
        private string pathToMaterialTable= "NOPATH";
        private string pathToWorkTable = "NOPATH";
        private string userLogin;

        public BrigadierForm(String login)//это логин бригадира
        {
            InitializeComponent();
            this.bregadierLogin = login;
            ReadFromFile();
            GetPaths();
        }

        private void GetPaths()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\OrdersTableByLogin.txt");
            string str = rd.ReadLine();
            string[] values;
            while (str != null)
            {
                values = str.Split('|');
                if (values[2] == bregadierLogin && values[6] == "false")
                {
                    pathToMaterialTable = values[7];
                    pathToWorkTable = values[8];
                    userLogin = values[0];
                    rd.Close();
                    return;
                }
                str = rd.ReadLine();
            }
            rd.Close();
        }

        private void ReadFromFile()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            string str = rd.ReadLine();
            string[] values;
            while (str != null)
            {
                values = str.Split('|');
                if (values[1] == bregadierLogin)
                {
                    if (values[3] != "true")// Если бригадир свободен
                    {
                        MessageBox.Show("У вас нет проектов");
                        this.Close();
                    }
                    rd.Close();
                    return;
                }
                str = rd.ReadLine();
            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MaterialsTableForm form = new MaterialsTableForm(pathToMaterialTable, "bregadier", bregadierLogin);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkTableForm form = new WorkTableForm(pathToWorkTable, "bregadier", bregadierLogin);
            form.ShowDialog();
        }
        private void ReportAboutFinishing()
        {
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\FinishedOrders.txt", true);
            wr.WriteLine(bregadierLogin + "|" + userLogin);
            wr.Flush();
            wr.Close();
            LiberateBregadier();
            MessageBox.Show("Система завершает вашу работу в аккаунте");
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {//уведомить о заверш строительства  
            ReportAboutFinishing();
        }

        private void LiberateBregadier()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            string str = rd.ReadLine();
            string[] values;
            while (str != null)
            {
                values = str.Split('|');
                if (values[1] == bregadierLogin) break;
                str = rd.ReadLine();
            }
            rd.Close();
            rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            String data = rd.ReadToEnd();rd.Close();
            StreamWriter wr = new StreamWriter(@"D:\DataForTSPP\BrigadiersFile.txt");
            wr.Write(data.Replace(str, str.Replace("true", "false")));
            wr.Close();
        }
    }
}
