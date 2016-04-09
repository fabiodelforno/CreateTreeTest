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
        FileStream fs = File.Open("reportCreateTree.txt", FileMode.Append);
        public ReportCreateTree() { }

        public ReportCreateTree(int d, int s, int aN, int aA, int nN)
        {
       // Depth: Split - Size: AttrNodi: AttrArchi:
            this.Depth = d;
            this.Split_Size = s;
            this.AttrNodo = aN;
            this.AttrArco = aA;
            this.NumberNodo = nN;
        }

        public int Depth { get; set; }
        public int Split_Size { get; set; }
        public int AttrNodo { get; set; }
        public int AttrArco { get; set; }
        public int NumberNodo { get; set; }

        private void initReport()
        {

            StreamWriter sw = new StreamWriter(fs);
            DateTime thisDay = DateTime.Today;
            string init = "" + thisDay.ToString("D");
            sw.WriteLine(init);
            sw.Flush();
            fs.Close();
        }
        
    }
}
