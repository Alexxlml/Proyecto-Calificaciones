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
    public partial class Alta_Calificaciones : Form
    {
        public Alta_Calificaciones()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        int asignacion = 0;
        int id_materia = 0;

        private void comboBox5_DropDown(object sender, EventArgs e)
        {
            CargaMaterias();
        }

        private void Alta_Calificaciones_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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
            AsignacionID();
            AsignarIDMateria();

            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("select al.no_control, CONCAT(al.apellidos,' ', al.nombre) as nombre, c.bloque1, c.bloque2, c.bloque3, c.bloque4, c.bloque5, c.observaciones " +
                "from calificaciones c " +
                "inner join materias m " +
                "on c.id_materia = m.id_materia " +
                "inner join alumnos al " +
                "on c.no_control = al.no_control " +
                "where al.id_asignacion = " + asignacion + " and c.id_materia = " + id_materia + " " +
                "ORDER by al.apellidos asc;");

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
        private void RegistrarCalificaciones()
        {
            bool bandera = false;
            try
            {

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    String no_control, comentarios;
                    String bq1, bq2, bq3, bq4, bq5;

                    AsignacionID();
                    AsignarIDMateria();

                    bq1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    bq2 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    bq3 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    bq4 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    bq5 = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    try
                    {
                        comentarios = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    }
                    catch 
                    {
                        comentarios = "Ninguno";
                    }
                    no_control = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    String nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    int b1tmp, b2tmp, b3tmp, b4tmp, b5tmp;
                    int b1, b2, b3, b4, b5;

                    b1tmp = int.Parse(bq1);
                    b2tmp = int.Parse(bq2);
                    b3tmp = int.Parse(bq3);
                    b4tmp = int.Parse(bq4);
                    b5tmp = int.Parse(bq5);

                    if (b1tmp > 100)
                    {
                        b1 = 100;
                    }
                    else 
                    {
                        b1 = b1tmp;
                    }

                    if (b2tmp > 100)
                    {
                        b2 = 100;
                    }
                    else
                    {
                        b2 = b2tmp;
                    }

                    if (b3tmp > 100)
                    {
                        b3 = 100;
                    }
                    else
                    {
                        b3 = b3tmp;
                    }

                    if (b4tmp > 100)
                    {
                        b4 = 100;
                    }
                    else
                    {
                        b4 = b4tmp;
                    }

                    if (b5tmp > 100)
                    {
                        b5 = 100;
                    }
                    else
                    {
                        b5 = b5tmp;
                    }


                    MySqlCommand comando1 = new MySqlCommand("UPDATE calificaciones set bloque1 = @bloque1, bloque2 = @bloque2, bloque3 = @bloque3, bloque4 = @bloque4, bloque5 = @bloque5, " +
                        "observaciones = @comentarios WHERE id_materia = @id_materia AND no_control = @no_control;");
                    comando1.Connection = Conexion;

                    MySqlParameter parametro0 = new MySqlParameter();
                    parametro0.ParameterName = "@id_materia";
                    parametro0.Value = id_materia;
                    comando1.Parameters.Add(parametro0);

                    MySqlParameter parametro1 = new MySqlParameter();
                    parametro1.ParameterName = "@no_control";
                    parametro1.Value = no_control;
                    comando1.Parameters.Add(parametro1);

                    MySqlParameter parametro2 = new MySqlParameter();
                    parametro2.ParameterName = "@bloque1";
                    parametro2.Value = b1;
                    comando1.Parameters.Add(parametro2);

                    MySqlParameter parametro3 = new MySqlParameter();
                    parametro3.ParameterName = "@bloque2";
                    parametro3.Value = b2;
                    comando1.Parameters.Add(parametro3);

                    MySqlParameter parametro4 = new MySqlParameter();
                    parametro4.ParameterName = "@bloque3";
                    parametro4.Value = b3;
                    comando1.Parameters.Add(parametro4);

                    MySqlParameter parametro5 = new MySqlParameter();
                    parametro5.ParameterName = "@bloque4";
                    parametro5.Value = b4;
                    comando1.Parameters.Add(parametro5);

                    MySqlParameter parametro6 = new MySqlParameter();
                    parametro6.ParameterName = "@bloque5";
                    parametro6.Value = b5;
                    comando1.Parameters.Add(parametro6);

                    MySqlParameter parametro7 = new MySqlParameter();
                    parametro7.ParameterName = "@comentarios";
                    parametro7.Value = comentarios;
                    comando1.Parameters.Add(parametro7);

                    try
                    {
                        Conexion.Open();
                        comando1.ExecuteNonQuery();
                        bandera = true;
                    }
                    catch
                    {
                        MessageBox.Show("Uno o mas alumnos que intentas calificar ya tienen registrada su calificación, procura consultar antes la lista de calificaciones registradas");
                        bandera = false;
                    }
                    Conexion.Close();
                }
                if (bandera == true)
                {
                    MessageBox.Show("Se registraron las calificaciones con éxito", "Modificar asistencia");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | comboBox2.Text == "" | comboBox5.Text == "")
            {
                MessageBox.Show("Antes de buscar asegúrate de seleccionar un valor para grado, uno para grupo y elegir una matería");
            }
            else
            {
                AsignacionID();
                MostrarTabla();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult modificar = MessageBox.Show("¿Estás seguro de que has seleccionado todas las calificaciones? \n" +
                "Si te equivocas en alguna, podrás corregirla después", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (modificar == DialogResult.Cancel)
            {

            }
            else
            {
                RegistrarCalificaciones();
            }
        }
    }
}
