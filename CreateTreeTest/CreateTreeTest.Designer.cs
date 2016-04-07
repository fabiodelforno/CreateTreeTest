namespace CreateTreeTest
{
    partial class CreateTreeTest
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.depthBox = new System.Windows.Forms.TextBox();
            this.splitBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioAttrDiversi = new System.Windows.Forms.RadioButton();
            this.radioAttrUguali = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.attrNodoBox = new System.Windows.Forms.TextBox();
            this.attrArcoBox = new System.Windows.Forms.TextBox();
            this.validazione = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.infoProgress = new System.Windows.Forms.Label();
            this.sfoglia = new System.Windows.Forms.Button();
            this.url = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numeri di nodi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Depth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Split-Size";
            // 
            // depthBox
            // 
            this.depthBox.Location = new System.Drawing.Point(17, 50);
            this.depthBox.Name = "depthBox";
            this.depthBox.Size = new System.Drawing.Size(38, 20);
            this.depthBox.TabIndex = 4;
            // 
            // splitBox
            // 
            this.splitBox.Location = new System.Drawing.Point(88, 50);
            this.splitBox.Name = "splitBox";
            this.splitBox.Size = new System.Drawing.Size(45, 20);
            this.splitBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lista Nomi attributi";
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(22, 183);
            this.numberBox.Name = "numberBox";
            this.numberBox.ReadOnly = true;
            this.numberBox.Size = new System.Drawing.Size(87, 20);
            this.numberBox.TabIndex = 11;
            this.numberBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Attributi nodo/arco";
            // 
            // radioAttrDiversi
            // 
            this.radioAttrDiversi.AutoSize = true;
            this.radioAttrDiversi.Location = new System.Drawing.Point(12, 99);
            this.radioAttrDiversi.Name = "radioAttrDiversi";
            this.radioAttrDiversi.Size = new System.Drawing.Size(92, 17);
            this.radioAttrDiversi.TabIndex = 13;
            this.radioAttrDiversi.TabStop = true;
            this.radioAttrDiversi.Text = "attributi diversi";
            this.radioAttrDiversi.UseVisualStyleBackColor = true;
            // 
            // radioAttrUguali
            // 
            this.radioAttrUguali.AutoSize = true;
            this.radioAttrUguali.Location = new System.Drawing.Point(12, 122);
            this.radioAttrUguali.Name = "radioAttrUguali";
            this.radioAttrUguali.Size = new System.Drawing.Size(90, 17);
            this.radioAttrUguali.TabIndex = 14;
            this.radioAttrUguali.TabStop = true;
            this.radioAttrUguali.Text = "attributi uguali";
            this.radioAttrUguali.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Attributo nodo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Attributo arco";
            // 
            // attrNodoBox
            // 
            this.attrNodoBox.Location = new System.Drawing.Point(137, 122);
            this.attrNodoBox.Multiline = true;
            this.attrNodoBox.Name = "attrNodoBox";
            this.attrNodoBox.ReadOnly = true;
            this.attrNodoBox.Size = new System.Drawing.Size(70, 81);
            this.attrNodoBox.TabIndex = 18;
            // 
            // attrArcoBox
            // 
            this.attrArcoBox.Location = new System.Drawing.Point(213, 122);
            this.attrArcoBox.Multiline = true;
            this.attrArcoBox.Name = "attrArcoBox";
            this.attrArcoBox.ReadOnly = true;
            this.attrArcoBox.Size = new System.Drawing.Size(68, 81);
            this.attrArcoBox.TabIndex = 19;
            // 
            // validazione
            // 
            this.validazione.Location = new System.Drawing.Point(23, 300);
            this.validazione.Name = "validazione";
            this.validazione.Size = new System.Drawing.Size(237, 35);
            this.validazione.TabIndex = 20;
            this.validazione.Text = "Validazione";
            this.validazione.UseVisualStyleBackColor = true;
            this.validazione.Click += new System.EventHandler(this.validazione_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 22);
            this.progressBar1.TabIndex = 21;
            // 
            // infoProgress
            // 
            this.infoProgress.AutoSize = true;
            this.infoProgress.Location = new System.Drawing.Point(120, 256);
            this.infoProgress.Name = "infoProgress";
            this.infoProgress.Size = new System.Drawing.Size(35, 13);
            this.infoProgress.TabIndex = 22;
            this.infoProgress.Text = "label8";
            // 
            // sfoglia
            // 
            this.sfoglia.Location = new System.Drawing.Point(23, 224);
            this.sfoglia.Name = "sfoglia";
            this.sfoglia.Size = new System.Drawing.Size(68, 27);
            this.sfoglia.TabIndex = 23;
            this.sfoglia.Text = "sfoglia";
            this.sfoglia.UseVisualStyleBackColor = true;
            this.sfoglia.Click += new System.EventHandler(this.sfoglia_Click);
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(97, 228);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(184, 20);
            this.url.TabIndex = 24;
            // 
            // CreateTreeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 338);
            this.Controls.Add(this.url);
            this.Controls.Add(this.sfoglia);
            this.Controls.Add(this.infoProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.validazione);
            this.Controls.Add(this.attrArcoBox);
            this.Controls.Add(this.attrNodoBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioAttrUguali);
            this.Controls.Add(this.radioAttrDiversi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numberBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitBox);
            this.Controls.Add(this.depthBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateTreeTest";
            this.Text = "CreateTreeTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox depthBox;
        private System.Windows.Forms.TextBox splitBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioAttrDiversi;
        private System.Windows.Forms.RadioButton radioAttrUguali;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox attrNodoBox;
        private System.Windows.Forms.TextBox attrArcoBox;
        private System.Windows.Forms.Button validazione;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label infoProgress;
        private System.Windows.Forms.Button sfoglia;
        private System.Windows.Forms.TextBox url;
    }
}

