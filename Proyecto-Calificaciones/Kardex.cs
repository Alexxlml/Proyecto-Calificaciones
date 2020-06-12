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

            MySqlCommand comandoconsulta = new MySqlCommand("select m.nombre, c.bloque1, c.bloque2, c.bloque3, c.bloque4, c.bloque5 " +
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
    }
}
