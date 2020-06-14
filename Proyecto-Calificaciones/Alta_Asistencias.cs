using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class Alta_Asistencias : Form
    {
        public Alta_Asistencias()
        {
            InitializeComponent();
        }

        int asignacion = 0;
        MySqlConnection Conexion = new MySqlConnection();

        private void Alta_Asistencias_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarTabla();
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
        private void MostrarTabla()
        {
            AsignacionID();

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("select al.no_control, concat(al.apellidos,' ',al.nombre) as nombre, al.foto   " +
                "from alumnos al  " +
                "inner join asignacion a " +
                "on al.id_asignacion = a.id_asignacion " +
                "where al.id_asignacion = '" + asignacion + "';");

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
        private void SeleccionaTodos()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }
        private void RegistrarAsistencias()
        {
            bool bandera = false;
            DialogResult registrar = MessageBox.Show("¿Deseas registrar la asistencia de los alumnos seleccionados?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (registrar == DialogResult.Cancel)
            {

            }
            else
            {

                try
                {

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {

                        String no_control, asistencia, asistencia_justificada;
                        String fecha_completa = dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss");

                        AsignacionID();

                        bool asistencia_grid = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                        no_control = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        if (asistencia_grid == true)
                        {
                            asistencia = "SI";
                            asistencia_justificada = "NO";
                        }
                        else 
                        {
                            asistencia = "NO";
                            asistencia_justificada = "NO";
                        }



                        MySqlCommand comando1 = new MySqlCommand("UPDATE calificaciones set bloque1 = @bloque1, bloque2 = @bloque2, bloque3 = @bloque3, bloque4 = @bloque4, bloque5 = @bloque5, " +
                            "observaciones = @comentarios WHERE id_materia = @id_materia AND no_control = @no_control;");
                        comando1.Connection = Conexion;

                        MySqlParameter parametro1 = new MySqlParameter();
                        parametro1.ParameterName = "@no_control";
                        parametro1.Value = no_control;
                        comando1.Parameters.Add(parametro1);

                        MySqlParameter parametro2 = new MySqlParameter();
                        parametro2.ParameterName = "@asistencia";
                        parametro2.Value = asistencia;
                        comando1.Parameters.Add(parametro2);

                        MySqlParameter parametro3 = new MySqlParameter();
                        parametro3.ParameterName = "@asistencia_justificada";
                        parametro3.Value = asistencia_justificada;
                        comando1.Parameters.Add(parametro3);

                        MySqlParameter parametro4 = new MySqlParameter();
                        parametro4.ParameterName = "@fecha_completa";
                        parametro4.Value = fecha_completa;
                        comando1.Parameters.Add(parametro4);

                        try
                        {
                            Conexion.Open();
                            comando1.ExecuteNonQuery();
                            bandera = true;
                        }
                        catch
                        {
                            MessageBox.Show("Hubo un error");
                            bandera = false;
                        }
                        Conexion.Close();
                    }
                    if (bandera == true)
                    {
                        MessageBox.Show("Se registraron las asistencias con éxito", "Alta asistencia");

                    }
                    else
                    {

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ha ocurrido un error" + err);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionaTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarAsistencias();
        }
    }
}
