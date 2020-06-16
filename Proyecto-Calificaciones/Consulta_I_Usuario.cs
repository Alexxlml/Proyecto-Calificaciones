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
    public partial class Consulta_I_Usuario : Form
    {
        public Consulta_I_Usuario()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        string correo, contraseña, nombre_completo, pregunta_secreta, respuesta_secreta, grado, grupo, tipo_de_usuario;
        int asignacionBD = 0;
        int tipoBD = 0;

        int asignacion = 0;
        int tipo = 0;
        int confirma = 0;
        bool confirmaif = false;
        bool confirmaBD_Programa = false;

        private void Consulta_I_Usuario_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;

            ConsultaCorreos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarUsuario();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deberá escribir de nuevo la respuesta de seguridad para autorizar la modificación de los datos del usuario");
            textBox4.Clear();
            HabilitarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ValidacionesInicio();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminaUsuario();
            LimpiarCampos();
            ConsultaCorreos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void EliminaUsuario()
        {
            correo = textBox1.Text;

            DialogResult eliminar = MessageBox.Show("Deseas eliminar este Usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (eliminar == DialogResult.Cancel)
            {

            }
            else
            {
                Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
                Conexion.ConnectionString = Cadenaconexion;

                MySqlCommand comando1 = new MySqlCommand("delete from usuarios where id_usuario= @id_usuario;");
                comando1.Connection = Conexion;

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@id_usuario";
                parametro1.Value = correo;
                comando1.Parameters.Add(parametro1);

                Conexion.Open();

                MySqlDataReader myreader = comando1.ExecuteReader();
                Conexion.Close();

                MessageBox.Show("El usuario fue eliminado con éxito");
            }
        }
        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        private void HabilitarCampos()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;

            button3.Enabled = true;
        }
        private void DeshabilitarCampos()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            button3.Enabled = false;
        }
        private void ConsultaCorreos()
        {
            Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            MySqlCommand comando1 = new MySqlCommand("Select id_usuario from usuarios");
            comando1.Connection = Conexion;

            Conexion.Open();
            MySqlDataReader myreader = comando1.ExecuteReader();
            AutoCompleteStringCollection micoleccion = new AutoCompleteStringCollection();

            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    micoleccion.Add(myreader.GetString(0));
                }
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se pueden obtener los usuarios", "Consulta Usuarios");
            }

            textBox1.AutoCompleteCustomSource = micoleccion;
            Conexion.Close();
        }
        private void BuscarUsuario()
        {
            button5.Enabled = true;
            Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            if (textBox1.Text == "")
            {
                MessageBox.Show("El campo de búsqueda no puede estar vacío");
            }
            else
            {
                correo = textBox1.Text;

                MySqlCommand comando2 = new MySqlCommand("Select * from usuarios Where id_usuario = @id_usuario");
                comando2.Connection = Conexion;

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@id_usuario";
                parametro1.Value = correo;
                comando2.Parameters.Add(parametro1);

                Conexion.Open();
                MySqlDataReader myreader = comando2.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        textBox3.Text = myreader[1] + "";
                        comboBox1.Text = myreader[3] + "";
                        textBox4.Text = myreader.IsDBNull(4) ? "" : myreader.GetString(4);
                        asignacionBD = (int)myreader[5];
                        tipoBD = (int)myreader[6];
                    }
                    AsignacionDeBDAlPrograma();
                    TipodeUsuarioDeBDAlPrograma();
                }
                else
                {
                    MessageBox.Show("No existe el usuario: " + correo, "Consulta Usuario");
                }
                Conexion.Close();

                MySqlCommand comando3 = new MySqlCommand("select aes_decrypt(pass,'" + textBox4.Text + "') from usuarios where id_usuario = '" + textBox1.Text + "';");
                comando3.Connection = Conexion;

                Conexion.Open();
                MySqlDataReader myreader3 = comando3.ExecuteReader();

                if (myreader3.HasRows)
                {
                    while (myreader3.Read())
                    {
                        textBox2.Text = myreader3.IsDBNull(0) ? "" : myreader3.GetString(0);

                    }

                }
                else
                {

                }
                Conexion.Close();

                button2.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void AsignacionDeBDAlPrograma()
        {
            if (asignacionBD == 1)
            {
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            else if (asignacionBD == 2)
            {
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 3)
            {
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 4)
            {
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 5)
            {
                comboBox2.SelectedIndex = 1;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 6)
            {
                comboBox2.SelectedIndex = 1;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 7)
            {
                comboBox2.SelectedIndex = 1;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 8)
            {
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 9)
            {
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 10)
            {
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 11)
            {
                comboBox2.SelectedIndex = 3;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 12)
            {
                comboBox2.SelectedIndex = 3;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 13)
            {
                comboBox2.SelectedIndex = 3;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 14)
            {
                comboBox2.SelectedIndex = 4;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 15)
            {
                comboBox2.SelectedIndex = 4;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 16)
            {
                comboBox2.SelectedIndex = 4;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 17)
            {
                comboBox2.SelectedIndex = 5;
                comboBox3.SelectedIndex = 0;
            }
            else if (asignacionBD == 18)
            {
                comboBox2.SelectedIndex = 5;
                comboBox3.SelectedIndex = 1;
            }
            else if (asignacionBD == 19)
            {
                comboBox2.SelectedIndex = 5;
                comboBox3.SelectedIndex = 2;
            }
            else if (asignacionBD == 20)
            {
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
        }
        private void TipodeUsuarioDeBDAlPrograma()
        {
            if (tipoBD == 0)
            {
                comboBox4.SelectedIndex = 2;
            }
            else if (tipoBD == 1)
            {
                comboBox4.SelectedIndex = 0;
            }
            else if (tipoBD == 2)
            {
                comboBox4.SelectedIndex = 1;
            }
        }

        private void AsignaId()
        {
            asignacion = 0;

            if (comboBox2.Text == "" && comboBox2.Text == "")
            {
                if (comboBox4.SelectedIndex == 0)
                {
                    asignacion = 1;
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    asignacion = 20;
                }

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
            if (comboBox4.SelectedIndex == 0)
            {
                tipo = 1;
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                tipo = 2;
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                tipo = 0;
            }
        }
        private void ValidacionesInicio()
        {
            DialogResult actualizar = MessageBox.Show("Desea realizar la modificación?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (actualizar == DialogResult.Cancel)
            {
                DeshabilitarCampos();
            }
            else
            {

                Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
                Conexion.ConnectionString = Cadenaconexion;

                if (comboBox4.Text == "Director" | comboBox4.Text == "Subdirector")
                {
                    if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | comboBox1.Text == "" | comboBox4.Text == "")
                    {
                        MessageBox.Show("Completa todos los campos antes de registrar un nuevo usuario");
                    }
                    else
                    {

                        ActualizaUsuario();
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
                        ActualizaUsuario();
                    }
                }
            }
        }
        private void ConfirmaAsignacion()
        {
            Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
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
        private void ConfirmaInfordeTipo()
        {
            int tipo_temporal = 0;

            if (comboBox4.SelectedIndex == 0)
            {
                tipo_temporal = 1;
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                tipo_temporal = 2;
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                tipo_temporal = 0;
            }

            if (tipoBD == tipo_temporal)
            {
                confirmaBD_Programa = true;
            }
            else
            {
                confirmaBD_Programa = false;
            }
        }
        private void ActualizaRegistros()
        {
            MySqlCommand comando1 = new MySqlCommand("UPDATE usuarios set nombre = @nombre_completo, pass = aes_encrypt(@contraseña,sha(@respuesta_secreta)), preg_recuperacion = @pregunta_secreta," +
                    "respuesta = sha(@respuesta_secreta), id_asignacion = @asignacion, tipo_usuario = @tipo_de_usuario where id_usuario = @correo");
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
            parametro5.ParameterName = "respuesta_secreta";
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
                MessageBox.Show("Datos actualizados con éxito", "Modificar de usuarios");

                LimpiarCampos();
            }
            catch
            {
                MessageBox.Show("Este usuario no se puede modificar");
            }
            Conexion.Close();
        }

        private void ActualizaUsuario()
        {
            correo = textBox1.Text;
            contraseña = textBox2.Text;
            nombre_completo = textBox3.Text;
            pregunta_secreta = comboBox1.Text;
            respuesta_secreta = textBox4.Text;
            grado = comboBox2.Text;
            grupo = comboBox3.Text;
            tipo_de_usuario = comboBox4.Text;

            AsignaId();
            TipoUsuario();
            ConfirmaAsignacion();
            ConfirmaInfordeTipo();

            if (confirmaBD_Programa == false)
            {
                if (confirmaif == true)
                {
                    if (confirma > 1 && confirma < 20)
                    {
                        MessageBox.Show("Este grado y grupo ya se ha asignado a un profesor, intenta con otro distinto");
                    }
                    else if (confirma == 1)
                    {
                        MessageBox.Show("Ya hay un director registrado, no puedes registrar otro");
                    }
                    else if (confirma == 20)
                    {
                        MessageBox.Show("Ya hay un Subdirector registrado, no puedes registrar otro a menos que elimines al actual o cambies sus provilegios a maestro");
                    }
                }
                else
                {
                    ActualizaRegistros();
                }
            }
            else
            {
                ActualizaRegistros();
            }
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
            if (comboBox4.Text == "Director" | comboBox4.Text == "Subdirector")
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

    }
}
