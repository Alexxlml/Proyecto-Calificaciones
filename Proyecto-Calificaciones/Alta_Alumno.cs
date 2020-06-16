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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_Calificaciones
{
    public partial class Alta_Alumno : Form
    {
        public Alta_Alumno()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();
        String Cadenaconexion;

        String no_control, no_tarjeta, nombre, apellidos, edad, tipo_sangre, alergias, domicilio, nombre_tutor, tel_tutor, nombre_p1, tel_p1, nombre_p2, tel_p2;
        int asignacion = 0;
        private string rutaimagen;

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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaFoto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Validaciones();
        }

        private void Alta_Alumno_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

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
        private void Validaciones()
        {
            Cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = Cadenaconexion;

            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == ""
              | comboBox1.Text == "" | comboBox2.Text == "" | comboBox3.Text == "" | comboBox4.Text == ""
              | pictureBox1.Image == null
               )
            {
                MessageBox.Show("Completa todos los campos antes de registrar un nuevo Alumno");
            }
            else
            {
                RegistrarAlumno();
            }
        }
        private void RegistrarAlumno()
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


            MySqlCommand comando1 = new MySqlCommand("INSERT INTO alumnos values (@no_control, @no_tarjeta, @nombre, @apellidos," +
                "@id_asignacion, @edad, @tipo_sangre, @alergias, " +
                "@domicilio, @nombre_tutor, @tel_tutor, @nombre_p1, " +
                "@tel_p1, @nombre_p2, @tel_p2, @foto);");

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
                MessageBox.Show("Datos insertados con éxito", "Registro de Alumnos");
                Conexion.Close();
                RegistrarAlumnoMaterias();
                //Limpiar();
            }
            catch (Exception err)
            {
                MessageBox.Show("Este Alumno ya está registrado" + err);
            }
        }

        private void RegistrarAlumnoMaterias() 
        {
            string num_control = textBox1.Text;
            int grado_combo = int.Parse(comboBox1.Text);
            int b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0;
            string observaciones = "";

            if (grado_combo == 1)
            {
                ForMaterias(1, 4, num_control, b1, b2, b3, b4, b5, observaciones);
            }
            if (grado_combo == 2)
            {
                ForMaterias(5, 8, num_control, b1, b2, b3, b4, b5, observaciones);
            }
            if (grado_combo == 3)
            {
                ForMaterias(9, 14, num_control, b1, b2, b3, b4, b5, observaciones);
            }
            if (grado_combo == 4)
            {
                ForMaterias(15, 21, num_control, b1, b2, b3, b4, b5, observaciones);
            }
            if (grado_combo == 5)
            {
                ForMaterias(22, 28, num_control, b1, b2, b3, b4, b5, observaciones);
            }
            if (grado_combo == 6)
            {
                ForMaterias(29, 35, num_control, b1, b2, b3, b4, b5, observaciones);
            }

        }

        private void ForMaterias(int v_i, int v_f, string num_control, int b1, int b2, int b3, int b4, int b5, string observaciones) 
        {
            for (int i = v_i; i <= v_f; i++)
            {
                int id_materia = i;

                MySqlCommand comando1 = new MySqlCommand("INSERT INTO calificaciones values ('" + id_materia + "','" + num_control + "','" + b1 + "','" + b2 + "','" + b3 + "','" + b4 + "','" + b5 + "','" + observaciones + "');");
                comando1.Connection = Conexion;

                try
                {
                    Conexion.Open();
                    comando1.ExecuteNonQuery();
                    Limpiar();
                }
                catch (Exception err)
                {
                    MessageBox.Show("" + err);
                }
                Conexion.Close();

            }
        }
    }
}
