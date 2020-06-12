using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class Alta_Usuario : Form
    {
        public Alta_Usuario()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        string correo, contraseña, nombre_completo, pregunta_secreta, respuesta_secreta, grado, grupo;
        int asignacion = 0;
        int tipo = 0;
        int confirma = 0;
        bool confirmaif = false;

        private void Alta_Usuario_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Subdirector")
            {
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidacionesInicio();
        }
        private void ValidacionesInicio()
        {
            Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            if (comboBox4.Text == "Subdirector")
            {
                if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | comboBox1.Text == "" | comboBox4.Text == "")
                {
                    MessageBox.Show("Completa todos los campos antes de registrar un nuevo usuario");
                }
                else
                {

                    RegistraUsuario();
                }
            }
            else if (comboBox4.Text == "Maestro")
            {
                if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == "")
                {
                    MessageBox.Show("Completa todos los campos antes de registrar un nuevo usuario");
                }
                else
                {
                    RegistraUsuario();
                }
            }
        }
        private void AsignaId()
        {
            asignacion = 0;

            if (comboBox2.Text == "" && comboBox2.Text == "")
            {
                asignacion = 20;
            }

            else if (comboBox2.Text == "1" && comboBox3.Text == "A")
            {
                asignacion = 2;
            }
            else if (comboBox2.Text == "1" && comboBox3.Text == "B")
            {
                asignacion = 3;
            }
            else if (comboBox2.Text == "1" && comboBox3.Text == "C")
            {
                asignacion = 4;
            }
            else if (comboBox2.Text == "2" && comboBox3.Text == "A")
            {
                asignacion = 5;
            }
            else if (comboBox2.Text == "2" && comboBox3.Text == "B")
            {
                asignacion = 6;
            }
            else if (comboBox2.Text == "2" && comboBox3.Text == "C")
            {
                asignacion = 7;
            }
            else if (comboBox2.Text == "3" && comboBox3.Text == "A")
            {
                asignacion = 8;
            }
            else if (comboBox2.Text == "3" && comboBox3.Text == "B")
            {
                asignacion = 9;
            }
            else if (comboBox2.Text == "3" && comboBox3.Text == "C")
            {
                asignacion = 10;
            }
            else if (comboBox2.Text == "4" && comboBox3.Text == "A")
            {
                asignacion = 11;
            }
            else if (comboBox2.Text == "4" && comboBox3.Text == "B")
            {
                asignacion = 12;
            }
            else if (comboBox2.Text == "4" && comboBox3.Text == "C")
            {
                asignacion = 13;
            }
            else if (comboBox2.Text == "5" && comboBox3.Text == "A")
            {
                asignacion = 14;
            }
            else if (comboBox2.Text == "5" && comboBox3.Text == "B")
            {
                asignacion = 15;
            }
            else if (comboBox2.Text == "5" && comboBox3.Text == "C")
            {
                asignacion = 16;
            }
            else if (comboBox2.Text == "6" && comboBox3.Text == "A")
            {
                asignacion = 17;
            }
            else if (comboBox2.Text == "6" && comboBox3.Text == "B")
            {
                asignacion = 18;
            }
            else if (comboBox2.Text == "6" && comboBox3.Text == "C")
            {
                asignacion = 19;
            }

        }
        private void TipoUsuario()
        {
            if (comboBox4.Text == "Subdirector")
            {
                tipo = 2;
            }
            else if (comboBox4.Text == "Maestro")
            {
                tipo = 0;
            }
        }
        private void ConfirmaAsignacion()
        {
            Cadenaconexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando2 = new MySqlCommand("SELECT id_asignacion from usuarios where id_asignacion = @ID;");
            comando2.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@ID";
            parametro1.Value = asignacion;
            comando2.Parameters.Add(parametro1);

            Conexion.Open();
            MySqlDataReader myreader = comando2.ExecuteReader();

            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    confirma = (int)myreader[0];
                    confirmaif = true;
                }

            }
            else
            {
                confirmaif = false;
            }
            Conexion.Close();
        }
        private void RegistraUsuario()
        {
            string email = textBox1.Text;
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            Match match = regex.Match(email);

            if (match.Success)
            {
                correo = textBox1.Text;
                contraseña = textBox2.Text;
                nombre_completo = textBox3.Text;
                pregunta_secreta = comboBox1.Text;
                respuesta_secreta = textBox4.Text;
                grado = comboBox2.Text;
                grupo = comboBox3.Text;

                AsignaId();
                TipoUsuario();
                ConfirmaAsignacion();

                if (confirma > 1 && confirma < 20 && confirmaif == true)
                {
                    MessageBox.Show("Este grado y grupo ya se ha asignado a un profesor, intenta con otro distinto");
                }
                else if (confirma == 20 && confirmaif == true)
                {
                    MessageBox.Show("Ya hay un Subdirector registrado, no puedes registrar otro a menos que elimines al actual o cambies sus provilegios a maestro");
                }
                else
                {

                    MySqlCommand comando1 = new MySqlCommand("INSERT INTO usuarios values (@correo, @nombre_completo, aes_encrypt(@contraseña,sha(@respuesta_secreta)), @pregunta_secreta, sha(@respuesta_secreta), @asignacion, @tipo_de_usuario)");
                    comando1.Connection = Conexion;

                    MySqlParameter parametro1 = new MySqlParameter();
                    parametro1.ParameterName = "@correo";
                    parametro1.Value = correo;
                    comando1.Parameters.Add(parametro1);

                    MySqlParameter parametro2 = new MySqlParameter();
                    parametro2.ParameterName = "@nombre_completo";
                    parametro2.Value = nombre_completo;
                    comando1.Parameters.Add(parametro2);

                    MySqlParameter parametro3 = new MySqlParameter();
                    parametro3.ParameterName = "@contraseña";
                    parametro3.Value = contraseña;
                    comando1.Parameters.Add(parametro3);

                    MySqlParameter parametro4 = new MySqlParameter();
                    parametro4.ParameterName = "@pregunta_secreta";
                    parametro4.Value = pregunta_secreta;
                    comando1.Parameters.Add(parametro4);

                    MySqlParameter parametro5 = new MySqlParameter();
                    parametro5.ParameterName = "@respuesta_secreta";
                    parametro5.Value = respuesta_secreta;
                    comando1.Parameters.Add(parametro5);

                    MySqlParameter parametro6 = new MySqlParameter();
                    parametro6.ParameterName = "@asignacion";
                    parametro6.Value = asignacion;
                    comando1.Parameters.Add(parametro6);

                    MySqlParameter parametro7 = new MySqlParameter();
                    parametro7.ParameterName = "@tipo_de_usuario";
                    parametro7.Value = tipo;
                    comando1.Parameters.Add(parametro7);

                    try
                    {
                        Conexion.Open();
                        comando1.ExecuteNonQuery();
                        MessageBox.Show("Datos insertados con éxito", "Registro de usuarios");
                        Limpiar();
                    }
                    catch
                    {
                        MessageBox.Show("Este usuario ya está registrado, intenta con otro correo");
                    }
                    Conexion.Close();
                }
            }
            else
            {

            }
        }
        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }
    }
}
