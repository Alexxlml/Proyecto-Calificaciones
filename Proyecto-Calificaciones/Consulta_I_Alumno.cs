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
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class Consulta_I_Alumno : Form
    {
        private string rutaimagen;
        string query;

        string no_control, no_tarjeta, nombre, apellidos, edad, tipo_sangre, alergias, domicilio, nombre_tutor, tel_tutor, nombre_p1, tel_p1, nombre_p2, tel_p2;
        int asignacionBD = 0;
        int asignacion = 0;

        public Consulta_I_Alumno()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        private void Consulta_I_Alumno_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void comboBox5_DropDownClosed(object sender, EventArgs e)
        {
            textBox13.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValidacionesInicio();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaFoto();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminaAlumno();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ValidacionesBusqueda();
        }

        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;

            pictureBox1.Image = pictureBox1.InitialImage;
        }
        private void CargaFoto()
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            Imagen.InitialDirectory = "C:/Users/inkis/Pictures";
            Imagen.Filter = "Archivos de imagen (*.jpeg)(*.jpeg)|*.jpg;.*jpeg|PNG (*.png)|*.png";
            if (Imagen.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = Imagen.FileName;
                rutaimagen = Imagen.FileName;
            }
            else
            {
                MessageBox.Show("Selecciona una fotografía del alumno por favor", "\n", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void EliminaAlumno()
        {
            string control = textBox1.Text;

            DialogResult eliminar = MessageBox.Show("Deseas eliminar este Alumno?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (eliminar == DialogResult.Cancel)
            {

            }
            else
            {
                Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
                Conexion.ConnectionString = Cadenaconexion;

                MySqlCommand comando1 = new MySqlCommand("delete from alumnos where no_control= @no_control;");
                comando1.Connection = Conexion;

                MySqlParameter parametro1 = new MySqlParameter();
                parametro1.ParameterName = "@no_control";
                parametro1.Value = control;
                comando1.Parameters.Add(parametro1);

                Conexion.Open();

                MySqlDataReader myreader = comando1.ExecuteReader();
                Conexion.Close();

                MessageBox.Show("El Alumno fue eliminado con éxito");
                Limpiar();
            }
        }
        private void AsignacionDeBDAlPrograma()
        {
            if (asignacionBD == 2)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 3)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 4)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionBD == 5)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 6)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 7)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionBD == 8)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 9)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 10)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionBD == 11)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 12)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 13)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionBD == 14)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 15)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 16)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionBD == 17)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionBD == 18)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionBD == 19)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 2;
            }
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
                string control = textBox13.Text;
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
                        textBox1.Text = myreader[0] + "";
                        textBox2.Text = myreader[1] + "";
                        textBox3.Text = myreader[2] + "";
                        textBox4.Text = myreader[3] + "";
                        asignacionBD = (int)myreader[4];
                        comboBox3.Text = myreader[5] + "";
                        comboBox4.Text = myreader[6] + "";
                        textBox5.Text = myreader[7] + "";
                        textBox6.Text = myreader[8] + "";
                        textBox7.Text = myreader[9] + "";
                        textBox8.Text = myreader[10] + "";
                        textBox9.Text = myreader[11] + "";
                        textBox10.Text = myreader[12] + "";
                        textBox11.Text = myreader[13] + "";
                        textBox12.Text = myreader[14] + "";
                    }
                    AsignacionDeBDAlPrograma();
                }
                else
                {
                    MessageBox.Show("No existe el " + comboBox5.Text + " : " + control, "Consulta Alumno");
                }
                Conexion.Close();
                ConsultaFoto();
            }
        }
        private void ConsultaFoto()
        {
            Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;
            MySqlCommand comando;
            MySqlDataAdapter da;

            String seletQuery = "SELECT * FROM alumnos WHERE no_control = '" + textBox1.Text + "'";
            comando = new MySqlCommand(seletQuery, Conexion);

            try
            {
                da = new MySqlDataAdapter(comando);

                DataTable table = new DataTable();

                da.Fill(table);

                if (da == null)
                {
                    pictureBox1 = null;
                }
                else
                {
                    byte[] img = (byte[])table.Rows[0]["foto"];

                    MemoryStream ms = new MemoryStream(img);

                    pictureBox1.Image = Image.FromStream(ms);

                    da.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la fotografía del alumno");
            }



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

        private void ValidacionesInicio()
        {
            DialogResult actualizar = MessageBox.Show("Desea realizar la modificación?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (actualizar == DialogResult.Cancel)
            {

            }
            else
            {

                Cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
                Conexion.ConnectionString = Cadenaconexion;

                if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == ""
              | pictureBox1.Image == null
                   )
                {
                    MessageBox.Show("Completa todos los campos antes de actualizar los datos del alumno");
                }
                else
                {

                    ActualizaRegistros();
                }
            }
        }

        private void ActualizaRegistros()
        {
            no_control = textBox1.Text;
            no_tarjeta = textBox2.Text;
            nombre = textBox3.Text;
            apellidos = textBox4.Text;
            edad = comboBox3.Text;
            tipo_sangre = comboBox4.Text;
            alergias = textBox5.Text;
            domicilio = textBox6.Text;
            nombre_tutor = textBox7.Text;
            tel_tutor = textBox8.Text;
            nombre_p1 = textBox9.Text;
            tel_p1 = textBox10.Text;
            nombre_p2 = textBox11.Text;
            tel_p2 = textBox12.Text;
            AsignacionID();

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] Foto = ms.ToArray();


            MySqlCommand comando1 = new MySqlCommand("UPDATE alumnos SET no_tarjeta = @no_tarjeta, nombre = @nombre, apellidos = @apellidos, " +
                "id_asignacion = @id_asignacion, edad = @edad, tipo_sangre = @tipo_sangre, alergias = @alergias, " +
                "domicilio = @domicilio, tutor = @nombre_tutor, tel_tutor = @tel_tutor, persona1 = @nombre_p1, " +
                "tel_persona1 = @tel_p1, persona2 = @nombre_p2, tel_persona2 = @tel_p2, foto = @foto WHERE no_control = @no_control");
            comando1.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@no_control";
            parametro1.Value = no_control;
            comando1.Parameters.Add(parametro1);

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@no_tarjeta";
            parametro2.Value = no_tarjeta;
            comando1.Parameters.Add(parametro2);

            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@nombre";
            parametro3.Value = nombre;
            comando1.Parameters.Add(parametro3);

            MySqlParameter parametro4 = new MySqlParameter();
            parametro4.ParameterName = "@apellidos";
            parametro4.Value = apellidos;
            comando1.Parameters.Add(parametro4);

            MySqlParameter parametro5 = new MySqlParameter();
            parametro5.ParameterName = "@id_asignacion";
            parametro5.Value = asignacion;
            comando1.Parameters.Add(parametro5);

            MySqlParameter parametro6 = new MySqlParameter();
            parametro6.ParameterName = "@edad";
            parametro6.Value = edad;
            comando1.Parameters.Add(parametro6);

            MySqlParameter parametro7 = new MySqlParameter();
            parametro7.ParameterName = "@tipo_sangre";
            parametro7.Value = tipo_sangre;
            comando1.Parameters.Add(parametro7);

            MySqlParameter parametro8 = new MySqlParameter();
            parametro8.ParameterName = "@alergias";
            parametro8.Value = alergias;
            comando1.Parameters.Add(parametro8);

            MySqlParameter parametro9 = new MySqlParameter();
            parametro9.ParameterName = "@domicilio";
            parametro9.Value = domicilio;
            comando1.Parameters.Add(parametro9);

            MySqlParameter parametro10 = new MySqlParameter();
            parametro10.ParameterName = "@nombre_tutor";
            parametro10.Value = nombre_tutor;
            comando1.Parameters.Add(parametro10);

            MySqlParameter parametro11 = new MySqlParameter();
            parametro11.ParameterName = "@tel_tutor";
            parametro11.Value = tel_tutor;
            comando1.Parameters.Add(parametro11);

            MySqlParameter parametro12 = new MySqlParameter();
            parametro12.ParameterName = "@nombre_p1";
            parametro12.Value = nombre_p1;
            comando1.Parameters.Add(parametro12);

            MySqlParameter parametro13 = new MySqlParameter();
            parametro13.ParameterName = "@tel_p1";
            parametro13.Value = tel_p1;
            comando1.Parameters.Add(parametro13);

            MySqlParameter parametro14 = new MySqlParameter();
            parametro14.ParameterName = "@nombre_p2";
            parametro14.Value = nombre_p2;
            comando1.Parameters.Add(parametro14);

            MySqlParameter parametro15 = new MySqlParameter();
            parametro15.ParameterName = "@tel_p2";
            parametro15.Value = tel_p2;
            comando1.Parameters.Add(parametro15);

            MySqlParameter parametro16 = new MySqlParameter();
            parametro16.ParameterName = "@foto";
            parametro16.Value = Foto;
            comando1.Parameters.Add(parametro16);

            try
            {
                Conexion.Open();
                comando1.ExecuteNonQuery();
                MessageBox.Show("Datos actualizados con éxito", "Modificar Alumno");

                Limpiar();
            }
            catch
            {
                MessageBox.Show("No se han podido actualizar los datos de este alumno");
            }
            Conexion.Close();
        }
    }
}
