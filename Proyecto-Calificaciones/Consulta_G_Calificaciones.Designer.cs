namespace Proyecto_Calificaciones
{
    partial class Consulta_G_Calificaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1240, 494);
            this.dataGridView1.TabIndex = 109;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 30);
            this.button1.TabIndex = 108;
            this.button1.Text = "Registrar calificaciones";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1132, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 107;
            this.button2.Text = "Cargar lista";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox2.Location = new System.Drawing.Point(759, 30);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(67, 28);
            this.comboBox2.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 105;
            this.label3.Text = "Grupo:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox1.Location = new System.Drawing.Point(579, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 28);
            this.comboBox1.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 103;
            this.label2.Text = "Grado:";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(928, 31);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(195, 28);
            this.comboBox5.TabIndex = 102;
            this.comboBox5.DropDown += new System.EventHandler(this.comboBox5_DropDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(832, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 25);
            this.label19.TabIndex = 101;
            this.label19.Text = "Materia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 31);
            this.label1.TabIndex = 100;
            this.label1.Text = "Consultar Calificaciones";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "no_control";
            this.Column1.HeaderText = "Número de control";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nombre";
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.DataPropertyName = "bloque1";
            this.Column3.HeaderText = "Bloque 1";
            this.Column3.Items.AddRange(new object[] {
            "100",
            "99",
            "98",
            "97",
            "96",
            "95",
            "94",
            "93",
            "92",
            "91",
            "90",
            "89",
            "88",
            "87",
            "86",
            "85",
            "84",
            "83",
            "82",
            "81",
            "80",
            "79",
            "78",
            "77",
            "76",
            "75",
            "74",
            "73",
            "72",
            "71",
            "70",
            "69",
            "68",
            "67",
            "66",
            "65",
            "64",
            "63",
            "62",
            "61",
            "60",
            "59",
            "58",
            "57",
            "56",
            "55",
            "54",
            "53",
            "52",
            "51",
            "50",
            "49",
            "48",
            "47",
            "46",
            "45",
            "44",
            "43",
            "42",
            "41",
            "40",
            "39",
            "38",
            "37",
            "36",
            "35",
            "34",
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Column3.Name = "Column3";
            this.Column3.Width = 55;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.DataPropertyName = "bloque2";
            this.Column4.HeaderText = "Bloque 2";
            this.Column4.Items.AddRange(new object[] {
            "100",
            "99",
            "98",
            "97",
            "96",
            "95",
            "94",
            "93",
            "92",
            "91",
            "90",
            "89",
            "88",
            "87",
            "86",
            "85",
            "84",
            "83",
            "82",
            "81",
            "80",
            "79",
            "78",
            "77",
            "76",
            "75",
            "74",
            "73",
            "72",
            "71",
            "70",
            "69",
            "68",
            "67",
            "66",
            "65",
            "64",
            "63",
            "62",
            "61",
            "60",
            "59",
            "58",
            "57",
            "56",
            "55",
            "54",
            "53",
            "52",
            "51",
            "50",
            "49",
            "48",
            "47",
            "46",
            "45",
            "44",
            "43",
            "42",
            "41",
            "40",
            "39",
            "38",
            "37",
            "36",
            "35",
            "34",
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Column4.Name = "Column4";
            this.Column4.Width = 55;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column5.DataPropertyName = "bloque3";
            this.Column5.HeaderText = "Bloque 3";
            this.Column5.Items.AddRange(new object[] {
            "100",
            "99",
            "98",
            "97",
            "96",
            "95",
            "94",
            "93",
            "92",
            "91",
            "90",
            "89",
            "88",
            "87",
            "86",
            "85",
            "84",
            "83",
            "82",
            "81",
            "80",
            "79",
            "78",
            "77",
            "76",
            "75",
            "74",
            "73",
            "72",
            "71",
            "70",
            "69",
            "68",
            "67",
            "66",
            "65",
            "64",
            "63",
            "62",
            "61",
            "60",
            "59",
            "58",
            "57",
            "56",
            "55",
            "54",
            "53",
            "52",
            "51",
            "50",
            "49",
            "48",
            "47",
            "46",
            "45",
            "44",
            "43",
            "42",
            "41",
            "40",
            "39",
            "38",
            "37",
            "36",
            "35",
            "34",
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Column5.Name = "Column5";
            this.Column5.Width = 55;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.DataPropertyName = "bloque4";
            this.Column6.HeaderText = "Bloque 4";
            this.Column6.Items.AddRange(new object[] {
            "100",
            "99",
            "98",
            "97",
            "96",
            "95",
            "94",
            "93",
            "92",
            "91",
            "90",
            "89",
            "88",
            "87",
            "86",
            "85",
            "84",
            "83",
            "82",
            "81",
            "80",
            "79",
            "78",
            "77",
            "76",
            "75",
            "74",
            "73",
            "72",
            "71",
            "70",
            "69",
            "68",
            "67",
            "66",
            "65",
            "64",
            "63",
            "62",
            "61",
            "60",
            "59",
            "58",
            "57",
            "56",
            "55",
            "54",
            "53",
            "52",
            "51",
            "50",
            "49",
            "48",
            "47",
            "46",
            "45",
            "44",
            "43",
            "42",
            "41",
            "40",
            "39",
            "38",
            "37",
            "36",
            "35",
            "34",
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Column6.Name = "Column6";
            this.Column6.Width = 55;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column7.DataPropertyName = "bloque5";
            this.Column7.HeaderText = "Bloque 5";
            this.Column7.Items.AddRange(new object[] {
            "100",
            "99",
            "98",
            "97",
            "96",
            "95",
            "94",
            "93",
            "92",
            "91",
            "90",
            "89",
            "88",
            "87",
            "86",
            "85",
            "84",
            "83",
            "82",
            "81",
            "80",
            "79",
            "78",
            "77",
            "76",
            "75",
            "74",
            "73",
            "72",
            "71",
            "70",
            "69",
            "68",
            "67",
            "66",
            "65",
            "64",
            "63",
            "62",
            "61",
            "60",
            "59",
            "58",
            "57",
            "56",
            "55",
            "54",
            "53",
            "52",
            "51",
            "50",
            "49",
            "48",
            "47",
            "46",
            "45",
            "44",
            "43",
            "42",
            "41",
            "40",
            "39",
            "38",
            "37",
            "36",
            "35",
            "34",
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Column7.Name = "Column7";
            this.Column7.Width = 55;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "observaciones";
            this.Column8.HeaderText = "Comentarios";
            this.Column8.Name = "Column8";
            // 
            // Consulta_G_Calificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 641);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Name = "Consulta_G_Calificaciones";
            this.Text = "Consulta_G_Calificaciones";
            this.Load += new System.EventHandler(this.Consulta_G_Calificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}