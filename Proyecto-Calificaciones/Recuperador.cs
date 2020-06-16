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
    public partial class Recuperador : Form
    {
        public Recuperador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login LG = new Login();
            LG.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacios");
            }
            else
            {
                String usuario = textBox1.Text;
                MySqlConnection conexion = new MySqlConnection();
                String cadenaconexion;
                cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
                conexion.ConnectionString = cadenaconexion;
                MySqlCommand comando1 = new MySqlCommand("Select preg_recuperacion from usuarios where id_usuario='" + usuario + "'");
                comando1.Connection = conexion;
                conexion.Open();

                MySqlDataReader myreader = comando1.ExecuteReader();
                String pregunta = "";
                try
                {
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            pregunta = myreader[0] + "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe el Usuario");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No existe el Usuario");
                }
                conexion.Close();

                if (pregunta == comboBox1.Text)
                {
                    String resp = textBox2.Text;

                    cadenaconexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
                    MySqlCommand comando2 = new MySqlCommand(String.Format("select aes_decrypt(pass,sha('" + resp + "')) from usuarios where id_usuario='" + usuario + "';"));
                    conexion.ConnectionString = cadenaconexion;
                    comando2.Connection = conexion;
                    conexion.Open();
                    myreader = comando2.ExecuteReader();

                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            textBox3.Text = myreader.IsDBNull(0) ? "" : myreader.GetString(0);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe", "Recuperador");
                        conexion.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Has introducido los datos incorrectos");
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Has introducido los datos incorrectos");
                }
            }
        }
    }
}
