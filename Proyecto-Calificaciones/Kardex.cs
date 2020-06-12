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
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class Kardex : Form
    {
        public Kardex()
        {
            InitializeComponent();
        }

        private void Kardex_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        string query;

        string no_control, nombre, apellidos;
        string grado, grupo;
        int asignacionBD = 0;
        string control;

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ValidacionesBusqueda();

            lbl_no_control.Text = no_control;
            lbl_nombre_completo.Text = apellidos + " " + nombre;
            lbl_grado.Text = grado;
            lbl_grupo.Text = grupo;
            MostrarTabla();

            if (lbl_no_control.Text != "") 
            {
                button1.Enabled = true;
            }

        }

        private void comboBox5_DropDownClosed(object sender, EventArgs e)
        {
            textBox13.Enabled = true;
        }

        private void ValidacionesBusqueda()
        {
            if (textBox13.Text == "")
            {
                MessageBox.Show("Tienes que elegir un campo de búsqueda y escribir en el antes de buscar");
            }
            else
            {
                Busqueda();
            }
        }
        private void Busqueda()
        {
            Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            if (textBox13.Text == "")
            {
                MessageBox.Show("El campo de búsqueda no puede estar vacío");
            }
            else
            {
                control = textBox13.Text;
                QueryBusqueda();

                MySqlCommand comando2 = new MySqlCommand(query);
                comando2.Connection = Conexion;

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@no_control";
                parametro1.Value = control;
                comando2.Parameters.Add(parametro1);

                MySqlParameter parametro2 = new MySqlParameter();
                parametro2.ParameterName = "@no_tarjeta";
                parametro2.Value = control;
                comando2.Parameters.Add(parametro2);

                MySqlParameter parametro3 = new MySqlParameter();
                parametro3.ParameterName = "@nombre_completo";
                parametro3.Value = control;
                comando2.Parameters.Add(parametro3);

                Conexion.Open();
                MySqlDataReader myreader = comando2.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        no_control = myreader[0] + "";
                        nombre = myreader[2] + "";
                        apellidos = myreader[3] + "";
                        asignacionBD = (int)myreader[4];
                    }
                    AsignacionDeBDAlPrograma();
                }
                else
                {
                    MessageBox.Show("No existe el " + comboBox5.Text + " : " + control, "Kardex");
                }
                Conexion.Close();
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox5.SelectedIndex == 0 | comboBox5.SelectedIndex == 1)
            {
                validacion.SoloNumeros(e);
                textBox13.MaxLength = 10;
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                validacion.SoloLetras(e);
                textBox13.MaxLength = 50;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirKardex();
        }

        private void QueryBusqueda()
        {
            if (comboBox5.SelectedIndex == 0)
            {
                query = "SELECT * FROM alumnos WHERE no_control = @no_control;";
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                query = "SELECT * FROM alumnos WHERE no_tarjeta = @no_tarjeta;";
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                query = "SELECT * FROM alumnos WHERE CONCAT(nombre,' ',apellidos) = @nombre_completo;";
            }
        }
        private void AsignacionDeBDAlPrograma()
        {
            if (asignacionBD == 2)
            {
                grado = "1";
                grupo = "A";
            }
            else if (asignacionBD == 3)
            {
                grado = "1";
                grupo = "B";
            }
            else if (asignacionBD == 4)
            {
                grado = "1";
                grupo = "C";
            }
            else if (asignacionBD == 5)
            {
                grado = "2";
                grupo = "A";
            }
            else if (asignacionBD == 6)
            {
                grado = "2";
                grupo = "B";
            }
            else if (asignacionBD == 7)
            {
                grado = "2";
                grupo = "C";
            }
            else if (asignacionBD == 8)
            {
                grado = "3";
                grupo = "A";
            }
            else if (asignacionBD == 9)
            {
                grado = "3";
                grupo = "B";
            }
            else if (asignacionBD == 10)
            {
                grado = "3";
                grupo = "C";
            }
            else if (asignacionBD == 11)
            {
                grado = "4";
                grupo = "A";
            }
            else if (asignacionBD == 12)
            {
                grado = "4";
                grupo = "B";
            }
            else if (asignacionBD == 13)
            {
                grado = "4";
                grupo = "C";
            }
            else if (asignacionBD == 14)
            {
                grado = "5";
                grupo = "A";
            }
            else if (asignacionBD == 15)
            {
                grado = "5";
                grupo = "B";
            }
            else if (asignacionBD == 16)
            {
                grado = "5";
                grupo = "C";
            }
            else if (asignacionBD == 17)
            {
                grado = "6";
                grupo = "A";
            }
            else if (asignacionBD == 18)
            {
                grado = "6";
                grupo = "B";
            }
            else if (asignacionBD == 19)
            {
                grado = "6";
                grupo = "C";
            }
        }
        private void MostrarTabla()
        {

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("select m.nombre, c.bloque1, c.bloque2, c.bloque3, c.bloque4, c.bloque5, " +
                "(bloque1 + bloque2 + bloque3 + bloque4 + bloque5)/5 as promedio " +
                "from calificaciones c " +
                "inner join materias m " +
                "on c.id_materia = m.id_materia " +
                "where m.grado = " + grado + " and c.no_control = " + no_control  +";");

            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView1.DataSource = Set.Tables[0];

            con.Dispose();
        }
        
        private void ImprimirKardex()
        {
            double promedio_sin = 0;
            double promedio = 0;
            int total_materias = dataGridView1.Rows.Count;
            DateTime fecha = DateTime.Now;

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                double suma = 0;
                suma = double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                promedio_sin = promedio_sin + suma;
            }

            promedio = promedio_sin / total_materias;
            double dos_digitos = (Math.Truncate(promedio * 100) / 100);

            String promedio_texto = dos_digitos.ToString();
            MessageBox.Show(promedio_texto);

            Document documento = new Document();
            PdfWriter wri = PdfWriter.GetInstance(documento, new FileStream("C:/NET/Kardex(" + no_control + ").pdf", FileMode.Create));
            documento.Open();

            // Creamos la imagen y le ajustamos el tamaño
            //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:/NET/");
            //imagen.BorderWidth = 0;
            //imagen.Alignment = Element.ALIGN_CENTER;
            //float percentage = 0.0f;
            //percentage = 150 / imagen.Width;
            //imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            //documento.Add(imagen);



            //Encabezado
            Paragraph title = new Paragraph(string.Format("Kardex"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.NORMAL));
            title.Alignment = Element.ALIGN_CENTER;
            documento.Add(title);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph Fecha_kardex = new Paragraph(string.Format("Fecha: " + fecha), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            Fecha_kardex.Alignment = Element.ALIGN_RIGHT;
            documento.Add(Fecha_kardex);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph nombre_kardex = new Paragraph(string.Format("Nombre: " + nombre + " " + apellidos), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            nombre_kardex.Alignment = Element.ALIGN_RIGHT;
            documento.Add(nombre_kardex);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph gradogrupo_kardex = new Paragraph(string.Format("Grado: " + grado + " Grupo: " + grupo), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            gradogrupo_kardex.Alignment = Element.ALIGN_RIGHT;
            documento.Add(gradogrupo_kardex);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph p_general = new Paragraph(string.Format("Promedio general: " + promedio_texto), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            p_general.Alignment = Element.ALIGN_RIGHT;
            documento.Add(p_general);
            documento.Add(new Paragraph("\n"));

            //Creación de la tabla
            PdfPTable pdfTable = new PdfPTable(7);
            pdfTable.WidthPercentage = 100;
            pdfTable.SetWidths(new float[] { 40, 10, 10, 10, 10, 10, 10 });

            pdfTable.AddCell(new Paragraph("Materia", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Bloque 1", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Bloque 2", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Bloque 3", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Bloque 4", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Bloque 5", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Promedio", FontFactory.GetFont("arial", 10, BaseColor.RED)));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    pdfTable.AddCell(celli.Value.ToString());
                }
            }
            documento.Add(pdfTable);
            documento.Add(new Paragraph("\n"));

            documento.Close();
            MessageBox.Show("El Kardex ha sido creado con éxito");
        }
    }
}
