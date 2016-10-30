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
    public partial class SetBrigadierForm : Form
    {
        internal static String bregadier = "";
        public SetBrigadierForm()
        {
            InitializeComponent();
            ReadFromFile();
        }
        public void ReadFromFile()
        {
            StreamReader rd = new StreamReader(@"D:\DataForTSPP\BrigadiersFile.txt");
            BrigadiersCmbBox.Items.Clear();
            string str = rd.ReadLine();
            string[] values;
            while(str != null)
            {
                values = str.Split('|');
                if(values[3] != "true")// Если бригадир свободен
                    BrigadiersCmbBox.Items.Add(values[1]);
                str = rd.ReadLine();
            }
            rd.Close();
        }
        public string GetBrigadier()
        {
            return bregadier;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = BrigadiersCmbBox.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Выделите бригадира");
                return;
            }
            bregadier = BrigadiersCmbBox.SelectedItem as String;
            DirectorForm.selectedBregadier = bregadier;
            this.Close();//??????????хз
        }

        private void button2_Click(object sender, EventArgs e)
        {//hire brigadier
            HireBrigadierForm hireBF = new HireBrigadierForm();
            hireBF.ShowDialog();
            ReadFromFile();
        }
    }
}
