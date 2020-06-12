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
    public partial class Consulta_G_Calificaciones : Form
    {
        public Consulta_G_Calificaciones()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        int asignacion = 0;
        int id_materia = 0;

        private void Consulta_G_Calificaciones_Load(object sender, EventArgs e)
        {

        }

        private void CargaMaterias()
        {
            String grado = comboBox1.Text;

            Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand("select nombre from materias where grado = '" + grado + "';");
            comando1.Connection = Conexion;

            Conexion.Open();
            MySqlDataAdapter con3 = new MySqlDataAdapter(comando1);
            DataSet Set3 = new DataSet();
            con3.Fill(Set3);

            try
            {
                comboBox5.DataSource = Set3.Tables[0];
                comboBox5.ValueMember = "nombre";
            }
            catch
            {
                MessageBox.Show("Selecciona un grado para poder elegir la materia correspondiente");
            }
            Conexion.Close();
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
        private void AsignarIDMateria()
        {
            String nombre_materia_temp = comboBox5.Text;

            Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand("select id_materia from materias where nombre = '" + nombre_materia_temp + "';");
            comando1.Connection = Conexion;

            Conexion.Open();
            MySqlDataReader myreader = comando1.ExecuteReader();
            AutoCompleteStringCollection micoleccion = new AutoCompleteStringCollection();

            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    id_materia = (int)myreader[0];
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener el ID de materia");
            }
            Conexion.Close();
        }
        private void MostrarTabla()
        {
            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("select no_control, concat(apellidos, ' ' ,nombre) as nombre from alumnos where id_asignacion = " + asignacion + " order by concat(apellidos, ' ' ,nombre) desc;");
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
    }
}
