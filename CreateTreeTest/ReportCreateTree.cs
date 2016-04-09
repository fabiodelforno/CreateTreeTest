using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTreeTest
{
    class ReportCreateTree
    {
       
        public ReportCreateTree() { }

        public ReportCreateTree(string t, int d, int s, int aN, int aA, int nN)
        {
            this.NameTree = t;
            this.Depth = d;
            this.Split_Size = s;
            this.AttrNodo = aN;
            this.AttrArco = aA;
            this.NumberNodi = nN;
            this.State = true;
        }

        public int Depth { get; set; }
        public int Split_Size { get; set; }
        public int AttrNodo { get; set; }
        public int AttrArco { get; set; }
        public int NumberNodi { get; set; }
        public string NameTree { get; set; }
        public bool State { get; set; }

        public void initReport(List<string> result)
        {

            DateTime thisDay = DateTime.Today;
            TimeZone localZone = TimeZone.CurrentTimeZone;
            string init = "" + thisDay.ToString("D") + "ora: " + localZone + "\n";
            string input = "Albero: " + this.NameTree + "\n" +" Depth: " + this.Depth +
                           " Split-Size: " + this.Split_Size + " | " + " AttributiNodo: "
                           + this.AttrNodo + " AttributiArco: " + this.AttrArco + " | " +" Numero di nodi: " +this.NumberNodi + "\n";
            string repo = "Correttezza Json: " + this.State + "\n";
            string error = "";
            foreach(string item in result)
            {
                error = item + "\n";
            }
            string endLine = "+++++++++++++++++++++++++++++++++++++\n";

            writeReport(init+input+repo+error+endLine);
            error = "";
           
        }

        private void writeReport(string repo)
        {
            FileStream fs = File.Open("reportCreateTree.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(repo);
            sw.Flush();
            fs.Close();
        }


    }
}
