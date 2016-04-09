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
            int ranNodo = r.Next(1, 5);
            int ranArco = r.Next(1, 5);
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
            //validazione Json
            //validazione correttezza dell'albero

            /**
             * l'albero è corretto se  
             * archi = nodi -1;(copertura)
             * nessun nodo isolato ??
             * numero di nodi generati corretti(correttezza)
             * numero di attributi corretti per arco e nodo
             */
           
           // StreamReader sr = File.OpenText(url.Text);
           // JsonTextReader jr = new JsonTextReader(sr);
            

            schemaJson();

        }

        //è una forma corretta di json?
        private async void schemaJson()
        {

            //la validazione viene fatta vertice per vertice
            string result = null;
            string resultTmp = null;
            StreamReader sr = File.OpenText(url.Text);
            infoProgress.Visible = true;
            infoProgress.Text = "opening file...";
            //Console.WriteLine("opening file...");
            //leggi la prima riga e controlla 
            //if( await sr.ReadLineAsync() != "[" )
            //{
            //    Console.WriteLine("not Json file");
            //    return;
            //}
            infoProgress.Text = "check file json...";
            if (await sr.ReadLineAsync() != "{") { Console.WriteLine("syntax error"); }
            while ( (resultTmp = await sr.ReadLineAsync()) != "}" )
            {
                //if( resultTmp != "{") { Console.WriteLine("syntax error"); }   
                //leggi fino a [
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
                            Console.WriteLine("syntax error");
                            return;
                        }
                    }
                    result = result + "}";
                    //Console.WriteLine("" + result);
                    //Console.WriteLine(" "+IsValidJson(result));
                    //if (!IsValidJson(result))
                    //{
                    //    Console.WriteLine("" + result);
                    //}
                    await Task.Run(() => IsValidJson(result));
                    result = null;
                    resultTmp = null;
                }
                
            }
            infoProgress.Text = "Finito, controlla il report!";

        }

        //check valid json file
        private static bool IsValidJson(string strInput)
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
                    return false;
                } catch (Exception ex)
                {
                    //some other exception 
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            } else {
                return false;
            }

        } 


    }
}
