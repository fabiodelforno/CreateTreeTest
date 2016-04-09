using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;
using Newtonsoft.Json.Schema;

namespace CreateTreeTest
{
    public partial class CreateTreeTest : Form
    {
        int ranNodo = 0;
        int ranArco = 0;
        List<string> error = new List<string>();

        public CreateTreeTest()
        {
            InitializeComponent();
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {

            numberBox.Clear();
            attrNodoBox.Clear();
            attrArcoBox.Clear();

            calculateNumberNode();
            if (radioAttrDiversi.Checked)
            {
                printListAttrD();
            }
            if (radioAttrUguali.Checked)
            {
                printListAttrU();
            }
            
        }
        private void printListAttrD()
        {
            Random r = new Random();
            ranNodo = r.Next(1, 5);
            ranArco = r.Next(1, 5);
            while ( ranArco==ranNodo )
            {
                ranArco = r.Next(1, 5);
            }
            printList(ranNodo, ranArco);
        }

        private void printListAttrU()
        {
            Random r = new Random();
            int ranNodo = r.Next(1, 5);
            printList(ranNodo, ranNodo);
        }

        private void printList(int n, int a)
        {
            int x = 1;
            while (x < n + 1)
            {
                attrNodoBox.Show();
                attrNodoBox.Paste("attrNodo" + x + "\n");
                x++;
            }
            x = 1;
            while (x < a + 1)
            {
                attrArcoBox.Show();
                attrArcoBox.Paste("attrArco" + x + "\n");
                x++;

            }
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
                //Console.WriteLine("numero nodi senza root: " + nodi);
            }else
            {
                if(split_size == 2)
                {
                    nodi = (int)Math.Pow(split_size, depth) - 1;
                    //Console.WriteLine("numero nodi senza root split=2: " + nodi);
                }
                else
                {
                    nodi += split_size;
                    //Console.WriteLine("numero nodi senza root depth=2: " + nodi);
                }
            }
            //nodo root
            nodi += 1;
            numberBox.Paste(nodi.ToString());
            numberBox.Show();
        }

        private void sfoglia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "json only.|*.json;";
            DialogResult dr = openfd.ShowDialog();
            url.Text = openfd.FileName;
        }

        private void validazione_Click(object sender, EventArgs e)
        {
            //validazione Json OK
            //validazione correttezza dell'albero
            
            //ToDo
            /**
             * l'albero è corretto se  
             * archi = nodi -1;(copertura)
             * nessun nodo isolato ??
             * numero di nodi generati corretti(correttezza) OK
             * numero di attributi corretti per arco e nodo  OK
             */      

            schemaJson();

        }
        

        //è una forma corretta di json?
        private async void schemaJson()
        {

            //la validazione viene svolta a blocchi di oggetti e array
            string result = null;
            string resultTmp = null;
            bool cheked = false;
            string nameTree = "";
            bool sentinella = false;
            StreamReader sr = File.OpenText(url.Text);
            infoProgress.Visible = true;
            infoProgress.Text = "opening file...";
         
           
            //instanzia report
            ReportCreateTree report = new ReportCreateTree();
            report.Depth = int.Parse(depthBox.Text);
            report.Split_Size = int.Parse(splitBox.Text);
            report.AttrNodo = ranNodo;
            report.AttrArco = ranArco;
            report.NumberNodi = int.Parse(numberBox.Text);
            report.State = true;

            infoProgress.Text = "check file json...";
            if (await sr.ReadLineAsync() != "{") { error.Add("manca una { riga 1 posizione 1"); }
            while ( (resultTmp = await sr.ReadLineAsync()) != "}" )
            {

                if (!sentinella)
                {
                    nameTree = resultTmp.Substring(15).Remove(resultTmp.Substring(15).Count() - 2);
                    Console.WriteLine("" + nameTree);
                    report.NameTree = nameTree;
                    sentinella = true;
                }
                
                while ((resultTmp = await sr.ReadLineAsync()).Trim() != "{" ) ;
                result += resultTmp;
                //legge tutti i vertici con gli attributi
                while ((resultTmp = await sr.ReadLineAsync()).Trim() != "]," && resultTmp.Trim() != "]")
                {
                    result = result + resultTmp;
                    //leggi da { fino a }, identifica un vertice con gli attributi
                    while ((resultTmp = await sr.ReadLineAsync()).Trim() != "]")
                    {
                        result = result + resultTmp;
                    }
                    result = result + resultTmp;
                    resultTmp = await sr.ReadLineAsync();
                    if (resultTmp.Trim() != "},")
                    {
                        if(resultTmp.Trim() != "}")
                        {
                            Console.WriteLine("manca una } verso la fine del file");
                            error.Add("manca una } verso la fine del file");
                            return;
                        }
                    }
                    result = result + "}";
                  
                    cheked = await Task.Run(() => IsValidJson(result));
                    if (!cheked) {
                        Console.WriteLine("" + cheked + ""+ error);
                        report.State = false; 
                    }
                    result = null;
                    resultTmp = null;
                }
                
            }
            infoProgress.Text = "init report...";
            report.initReport(error);
            infoProgress.Text = "Finito, controlla il report!";
 
        }
        
        //check valid json file
        private bool IsValidJson(string strInput)
        {
            
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array 
            {
                try {
                    var obj = JToken.Parse(strInput);
                    return true;
                } catch (JsonReaderException jex) {
                    //Exception in parsing json 
                    Console.WriteLine(jex.Message);
                    error.Add(jex.Message);
                    return false;
                } catch (Exception ex)
                {
                    //some other exception 
                    Console.WriteLine(ex.ToString());
                    error.Add(ex.ToString());
                    return false;
                }
            } else {
                Console.WriteLine("Manca una parentesi [ oppure {");
                error.Add("Manca una parentesi [ oppure {");
                return false;
            }

        } 


    }
}
