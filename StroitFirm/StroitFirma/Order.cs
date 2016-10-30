using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroitFirma
{
    class Order
    {
        //path to material table == @"C:\MaterialTables\MaterialTable_"+owner+ number of order
        // the same with path to work table
        public String owner
        {
            get;
            private set;
        }
        int ID;
        String brigadier;
        DateTime completionTime;
        float paid, toPay;
        public bool buildingComplete{get; set;}
        String pathToMaterialTable, pathToWorkTable;
        /*public String PathToMaterialTable
        {
            get { return pathToMaterialTable; }
            set
            {
                if (PathToMaterialTable == "NOPATH")
                {
                    pathToMaterialTable = value;
                }
            }
        }*/
        public void SetPathToMaterialTable(String path)
        {
            if (pathToMaterialTable == "NOPATH")
                pathToMaterialTable = path;
        }
        public String GetPathToMaterialTable()
        {
            return pathToMaterialTable;
        }
        public void SetPathToWorkTable(String path)
        {
            if (pathToWorkTable == "NOPATH")
                pathToWorkTable = path;
        }
        public String GetPathToWorkTable()
        {
            return pathToWorkTable;
        }
        public float HowMuchToPay()
        {
            return toPay;
        }
        public override string ToString()
        {
            string time = Convert.ToString(completionTime);
            string[] parts = time.Split('.');
            String oldValue0 = parts[0];
            String oldValue1 = parts[1];
            if (parts[0][0] == '0') parts[0] = parts[0].Substring(1);
            if (parts[1][0] == '0') parts[1] = parts[1].Substring(1);
            time = time.Replace(oldValue0 + ".", parts[0] + ".");
            time = time.Replace("." + oldValue1 + ".", "."+parts[1]+".");
            return owner + "|" + ID + "|" + brigadier + "|" + time + "|" +
                paid + "|" + toPay + "|" + buildingComplete.ToString().ToLower() + "|" + pathToMaterialTable + "|" + pathToWorkTable;
        }

        public Order(String owner, int ID, String brigadier, DateTime completionTime, float paid = 0,
            float toPay = 0, bool buildingComplete = false, String p1 = "NOPATH", String p2 = "NOPATH")
        {
            this.owner = owner;//owner - login of the user
            this.ID = ID;
            this.brigadier = brigadier;
            this.completionTime = completionTime;
            this.paid = paid;this.toPay = toPay;
            this.buildingComplete = buildingComplete;
            pathToMaterialTable = p1;
            pathToWorkTable = p2;
        }

        public void Pay(float payment)
        {
            paid += payment;
            toPay -= payment;  
        }

        public void ShowInformation()
        {
            MessageBox.Show("Владелец: "+owner+"\n"+
                "Бригадир: " + brigadier + "\n" +
                "К оплате: " + toPay + "\n" +
                "Оплачено: " + paid + "\n" +
                "Дата окончания строительства: " + completionTime + "\n" +
                "Строительство " + (buildingComplete?"завершено":"не завершено") + "\n");
        }


    }
}
