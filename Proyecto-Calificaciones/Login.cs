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
using System.Text.RegularExpressions;

namespace Proyecto_Calificaciones
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection();
        String cadenaconexion;

        string usuario;
        string pass = "";
        string pass_base = "";
        string usr1 = "";
        string resp = "";
        int perfil = 0;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperador R = new Recuperador();
            R.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            Match match = regex.Match(email);

            if (textBox1.Text == "" | textBox2.Text == ""){
                MessageBox.Show("Los campos no pueden estar vacios");
            }
            else {
                if (match.Success)
                {
                    usuario = textBox1.Text;
                    pass = textBox2.Text;

                    cadenaconexion = "Server=localhost; Port=3306; User id=root; Database=boletas; Password=azr4510m";
                    conexion.ConnectionString = cadenaconexion;

                    MySqlCommand comando1 = new MySqlCommand("Select respuesta from usuarios where id_usuario='" + usuario + "'");
                    comando1.Connection = conexion;
                    conexion.Open();

                    MySqlDataReader myreader = comando1.ExecuteReader();

                    try
                    {
                        if (myreader.HasRows)
                        {
                            while (myreader.Read())
                            {
                                resp = myreader[0] + "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existe el Usuario, crea uno antes de acceder");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    conexion.Close();

                    MySqlCommand comando2 = new MySqlCommand("select id_usuario from usuarios where pass=aes_encrypt('" + pass + "','" + resp + "') and id_usuario= '" + usuario + "';");
                    comando2.Connection = conexion;
                    conexion.Open();
                    MySqlDataReader myreader2 = comando2.ExecuteReader();
                    try
                    {
                        if (myreader2.HasRows)
                        {
                            while (myreader2.Read())
                            {
                                usr1 = myreader2[0] + "";

                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {

                    }
                    conexion.Close();


                    MySqlCommand comando7 = new MySqlCommand("select aes_decrypt(pass,'" + resp + "') from usuarios where id_usuario='" + usuario + "';");
                    comando7.Connection = conexion;
                    conexion.Open();
                    MySqlDataReader myreader7 = comando7.ExecuteReader();
                    try
                    {
                        if (myreader7.HasRows)
                        {
                            while (myreader7.Read())
                            {
                                pass_base = myreader7.IsDBNull(0) ? "" : myreader7.GetString(0);

                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {

                    }
                    conexion.Close();

                    MySqlCommand comando8 = new MySqlCommand("select tipo_usuario from usuarios where id_usuario = '" + usuario + "';");
                    comando8.Connection = conexion;
                    conexion.Open();
                    MySqlDataReader myreader8 = comando8.ExecuteReader();
                    try
                    {
                        if (myreader8.HasRows)
                        {
                            while (myreader8.Read())
                            {
                                perfil = (int)myreader8[0];

                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception)
                    {

                    }
                    conexion.Close();

                    if (textBox1.Text == usr1 && textBox2.Text == pass_base)
                    {
                        if (perfil == 1)
                        {
                            Menu_Admin administrador = new Menu_Admin();
                            administrador.Show();
                            this.Hide();
                        }
                        else if (perfil == 0)
                        {
                            Menu_Maestro maestro = new Menu_Maestro();
                            maestro.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario y contraseña ingresados son incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario: " + email + " no es válido" + "\n Por favor verifica que el correo introducido esté correctamente escrito");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
