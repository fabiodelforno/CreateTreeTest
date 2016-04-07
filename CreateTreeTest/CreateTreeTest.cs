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
        
        private void schemaJson()
        {
            string schemaJson = @"{
                    'type': 'object',
                    'properties': {
                        'name': {'type':'string'},
                        'roles': {'type': 'array'}
                    }
            }";

            string JSON = @"{ 
                    'name': 'pino', 
                    'roles': ['Invalid content', 0.123456789] 
                    } ";

            JSchema schema = JSchema.Parse(schemaJson);
            JObject person = JObject.Parse(JSON);
            IList<string> messages;
            bool valid = person.IsValid(schema, out messages);
            Console.WriteLine(valid);
            foreach(string outline in messages)
            {
                Console.WriteLine(outline);
            }
            //JsonTextReader reader = new JsonTextReader(new StringReader(JSON));
            //JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            //validatingReader.Schema = JSchema.Parse(schemaJson);
            //IList<string> messages = new List<string>();
            //validatingReader.va
            //validatingReader.ValidationEventHandler += (o, a) => messages.Add(a.Message);
            //bool isValid = (messages.Count == 0);
            //Console.WriteLine(isValid);

        }


    }
}
