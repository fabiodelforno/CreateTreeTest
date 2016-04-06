using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateTreeTest
{
    public partial class CreateTreeTest : Form
    {
        public CreateTreeTest()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            calculateNumberNode();
        }

        private void calculateNumberNode()
        {
            int nodi = 0;
            int depth = int.Parse(depthBox.Text);
            int split_size = int.Parse(splitBox.Text);
            if (depth == 1) return;
            if (split_size != 2 && depth != 2)
            {
                nodi = (int)Math.Pow(split_size, depth - 1);
                nodi += split_size;
                Console.WriteLine("numero nodi senza root: " + nodi);
            }else
            {
                if(split_size == 2)
                {
                    nodi = (int)Math.Pow(split_size, depth) - 1;
                    Console.WriteLine("numero nodi senza root split=2: " + nodi);
                }
                else
                {
                    nodi += split_size;
                    Console.WriteLine("numero nodi senza root depth=2: " + nodi);
                }
            }

        }
        
    }
}
