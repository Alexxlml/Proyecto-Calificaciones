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
    public partial class Consulta_Asistencias : Form
    {

        public Consulta_Asistencias(string usr1, int perfil, int id_asignacion)
        {
            this.usr1 = usr1;
            this.perfil = perfil;
            this.id_asignacion = id_asignacion;
            InitializeComponent();
        }

        int asignacion = 0;
        int asignacionLogin = 0;

        private void Consulta_Asistencias_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            MuestraPrivilegios();
        }

        MySqlConnection Conexion = new MySqlConnection();
        private string usr1;
        private int perfil;
        private int id_asignacion;

        private void AplicaPrivilegios()
        {
            if (perfil == 1 | perfil == 2)
            {
                ConsultaEspecifica(asignacion);
            }
            else if (perfil == 0)
            {
                ConsultaEspecifica(asignacionLogin);
            }
        }
        private void MuestraPrivilegios()
        {
            if (perfil == 1 | perfil == 2)
            {
                label3.Enabled = true;
                label4.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Enabled = true;

                label3.Visible = true;
                label4.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                button3.Visible = true;
                

            }
            else if (perfil == 0)
            {
                label3.Enabled = false;
                label4.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                btn_porcentaje.Enabled = false;
                btn_porcentaje.Visible = false;
                //button3.Enabled = false;

                //label3.Visible = false;
                //label4.Visible = false;
                //comboBox1.Visible = false;
                //comboBox2.Visible = false;
                //button3.Visible = false;
                AsignacionDeLoginAlPrograma();

            }
        }
        private void AsignacionDeLoginAlPrograma()
        {
            asignacionLogin = id_asignacion;

            if (asignacionLogin == 1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else if (asignacionLogin == 2)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 3)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 4)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 5)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 6)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 7)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 8)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 9)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 10)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 11)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 12)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 13)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 14)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 15)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 16)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 17)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 18)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 19)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 20)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }
        private void ConsultaEspecifica(int id_a)
        {
            AsignacionID();
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("SELECT al.no_control, CONCAT(al.apellidos,' ',al.nombre) as nombre, a.grado, a.grupo, asis.asistencia, asis.asistencia_justificada, asis.fecha, al.foto " +
                "FROM alumnos al " +
                "INNER JOIN asignacion a " +
                "ON	al.id_asignacion = a.id_asignacion " +
                "INNER JOIN asistencias asis " +
                "ON al.no_control = asis.no_control " +
                "WHERE a.id_asignacion = '" + id_a + "' AND asis.fecha like '" + fecha + "%';");

            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView1.DataSource = Set.Tables[0];

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            con.Dispose();
        }
        private void ConsultaAsistenciaPDF()
        {
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("SELECT al.no_control, CONCAT(al.apellidos,' ',al.nombre) as nombre, a.grado, a.grupo " +
                "FROM alumnos al " +
                "INNER JOIN asignacion a " +
                "ON	al.id_asignacion = a.id_asignacion " +
                "INNER JOIN asistencias asis " +
                "ON al.no_control = asis.no_control " +
                "WHERE a.id_asignacion = '" + asignacion + "' " +
                "AND asis.asistencia = 'SI' " +
                "AND asis.fecha like '" + fecha + "%';");
            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowTemplate.Height = 120;
            dataGridView2.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView2.DataSource = Set.Tables[0];

            con.Dispose();
        }
        private void ImprimirAsistencia()
        {
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            Document documento = new Document();
            PdfWriter wri = PdfWriter.GetInstance(documento, new FileStream("C:/NET/Reporte_Asistencias(" + fecha + ").pdf", FileMode.Create));
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
            Paragraph title = new Paragraph(string.Format("Reporte de asistencias"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.NORMAL));
            title.Alignment = Element.ALIGN_CENTER;
            documento.Add(title);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph Fecha_Nota = new Paragraph(string.Format("Fecha: " + fecha), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            Fecha_Nota.Alignment = Element.ALIGN_LEFT;
            documento.Add(Fecha_Nota);
            documento.Add(new Paragraph("\n\n"));

            //Creación de la tabla
            PdfPTable pdfTable = new PdfPTable(4);
            pdfTable.WidthPercentage = 100;
            pdfTable.SetWidths(new float[] { 40, 40, 10, 10 });

            pdfTable.AddCell(new Paragraph("Número de control", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Nombre", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Grado", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Grupo", FontFactory.GetFont("arial", 10, BaseColor.RED)));

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    pdfTable.AddCell(celli.Value.ToString());
                }
            }
            documento.Add(pdfTable);
            documento.Add(new Paragraph("\n"));

            documento.Close();
            MessageBox.Show("El reporte de asistencias ha sido creado con éxito");
        }
        private void ConsultaInasistenciaPDF()
        {
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("SELECT al.no_control, CONCAT(al.apellidos,' ',al.nombre) as nombre, a.grado, a.grupo, al.tutor, al.tel_tutor " +
                "FROM alumnos al " +
                "INNER JOIN asignacion a " +
                "ON	al.id_asignacion = a.id_asignacion " +
                "INNER JOIN asistencias asis " +
                "ON al.no_control = asis.no_control " +
                "WHERE a.id_asignacion = '" + asignacion + "' " +
                "AND asis.asistencia = 'NO' " +
                "AND asis.fecha like '" + fecha + "%';");

            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.RowTemplate.Height = 120;
            dataGridView3.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView3.DataSource = Set.Tables[0];

            con.Dispose();
        }
        private void ImprimirInasistencia()
        {
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            Document documento = new Document();
            PdfWriter wri = PdfWriter.GetInstance(documento, new FileStream("C:/NET/Reporte_Inasistencias(" + fecha + ").pdf", FileMode.Create));
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
            Paragraph title = new Paragraph(string.Format("Reporte de inasistencias"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.NORMAL));
            title.Alignment = Element.ALIGN_CENTER;
            documento.Add(title);
            documento.Add(new Paragraph("\n"));

            //Fecha
            Paragraph Fecha_Nota = new Paragraph(string.Format("Fecha: " + fecha), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
            Fecha_Nota.Alignment = Element.ALIGN_LEFT;
            documento.Add(Fecha_Nota);
            documento.Add(new Paragraph("\n\n"));

            //Creación de la tabla
            PdfPTable pdfTable = new PdfPTable(6);
            pdfTable.WidthPercentage = 100;
            pdfTable.SetWidths(new float[] { 10, 30, 10, 10, 30, 10 });

            pdfTable.AddCell(new Paragraph("Número de control", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Nombre", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Grado", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Grupo", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Nombre del tutor", FontFactory.GetFont("arial", 10, BaseColor.RED)));
            pdfTable.AddCell(new Paragraph("Teléfono del tutor", FontFactory.GetFont("arial", 10, BaseColor.RED)));

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    pdfTable.AddCell(celli.Value.ToString());
                }
            }
            documento.Add(pdfTable);
            documento.Add(new Paragraph("\n"));

            documento.Close();
            MessageBox.Show("El reporte de Inasistencias ha sido creado con éxito");
        }
        private void AsignacionID()
        {
            asignacion = 0;

            if (comboBox1.Text == "1" && comboBox2.Text == "A")
            {
                asignacion = 2;
            }
            else if (comboBox1.Text == "1" && comboBox2.Text == "B")
            {
                asignacion = 3;
            }
            else if (comboBox1.Text == "1" && comboBox2.Text == "C")
            {
                asignacion = 4;
            }
            else if (comboBox1.Text == "2" && comboBox2.Text == "A")
            {
                asignacion = 5;
            }
            else if (comboBox1.Text == "2" && comboBox2.Text == "B")
            {
                asignacion = 6;
            }
            else if (comboBox1.Text == "2" && comboBox2.Text == "C")
            {
                asignacion = 7;
            }
            else if (comboBox1.Text == "3" && comboBox2.Text == "A")
            {
                asignacion = 8;
            }
            else if (comboBox1.Text == "3" && comboBox2.Text == "B")
            {
                asignacion = 9;
            }
            else if (comboBox1.Text == "3" && comboBox2.Text == "C")
            {
                asignacion = 10;
            }
            else if (comboBox1.Text == "4" && comboBox2.Text == "A")
            {
                asignacion = 11;
            }
            else if (comboBox1.Text == "4" && comboBox2.Text == "B")
            {
                asignacion = 12;
            }
            else if (comboBox1.Text == "4" && comboBox2.Text == "C")
            {
                asignacion = 13;
            }
            else if (comboBox1.Text == "5" && comboBox2.Text == "A")
            {
                asignacion = 14;
            }
            else if (comboBox1.Text == "5" && comboBox2.Text == "B")
            {
                asignacion = 15;
            }
            else if (comboBox1.Text == "5" && comboBox2.Text == "C")
            {
                asignacion = 16;
            }
            else if (comboBox1.Text == "6" && comboBox2.Text == "A")
            {
                asignacion = 17;
            }
            else if (comboBox1.Text == "6" && comboBox2.Text == "B")
            {
                asignacion = 18;
            }
            else if (comboBox1.Text == "6" && comboBox2.Text == "C")
            {
                asignacion = 19;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaAsistenciaPDF();
            ImprimirAsistencia();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            ConsultaInasistenciaPDF();
            ImprimirInasistencia();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AplicaPrivilegios();
            button1.Enabled = true;
            btn_Eliminar.Enabled = true;
            btn_porcentaje.Enabled = true;
            btn_porcentaje.Visible = true;
        }

        private void btn_porcentaje_Click(object sender, EventArgs e)
        {
            ConsultaPorcentajes();
            ImprimeExcel();
        }

        private void ConsultaPorcentajes() 
        {
            String fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("CALL porcentajes('" + fecha + "');");
            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.RowTemplate.Height = 120;
            dataGridView4.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView4.DataSource = Set.Tables[0];

            con.Dispose();
        }
        private void ImprimeExcel() 
        {
            if (dataGridView4.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 2; i < dataGridView4.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dataGridView4.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int j = 1; j < dataGridView4.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dataGridView4.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }


}
