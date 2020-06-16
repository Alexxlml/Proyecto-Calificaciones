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
        private string usr1;
        private int perfil;
        private int id_asignacion;
        public Alta_Asistencias(string usr1, int perfil, int id_asignacion)
        {
            this.usr1 = usr1;
            this.perfil = perfil;
            this.id_asignacion = id_asignacion;
            InitializeComponent();
        }

        int asignacion = 0;
        int asignacionLogin = 0;

        int ra_idasignacion = 0;
        String ra_fecha = "", fecha_dt = "";

        MySqlConnection Conexion = new MySqlConnection();


        private void Alta_Asistencias_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;

            MuestraPrivilegios();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (perfil == 1 | perfil == 2)
            {
                dateTimePicker1.Enabled = true;
                dataGridView1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;

                AsignacionID();
                RevisarAsistencias(asignacion);
                RevisaRA(asignacion);
            }
            else
            {

            }
        }

        private void AsignacionDeLoginAlPrograma()
        {
            asignacionLogin = id_asignacion;

            if (asignacionLogin == 1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else if (asignacionLogin == 2)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 3)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 4)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 5)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 6)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 7)
            {
                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 8)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 9)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 10)
            {
                comboBox1.SelectedIndex = 2;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 11)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 12)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 13)
            {
                comboBox1.SelectedIndex = 3;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 14)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 15)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 16)
            {
                comboBox1.SelectedIndex = 4;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 17)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 0;
            }
            else if (asignacionLogin == 18)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 1;
            }
            else if (asignacionLogin == 19)
            {
                comboBox1.SelectedIndex = 5;
                comboBox2.SelectedIndex = 2;
            }
            else if (asignacionLogin == 20)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
        private void MostrarTabla()
        {
            AsignacionID();

            String CadenaConexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
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



                        MySqlCommand comando1 = new MySqlCommand("INSERT INTO asistencias values (@no_control, @asistencia, @asistencia_justificada, @fecha_completa);");
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
                            Conexion.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Hubo un error \n\n" + err);
                            bandera = false;
                        }

                    }
                    if (bandera == true)
                    {
                        RegistroDiario();
                        BloquearRegistro();
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
        private void RegistroDiario()
        {
            String fecha_corta = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            MySqlCommand comando1 = new MySqlCommand("INSERT INTO registro_asistencias values (@id_usuario, @fecha_corta, @id_asignacion)");
            comando1.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@id_usuario";
            parametro1.Value = usr1;
            comando1.Parameters.Add(parametro1);

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@fecha_corta";
            parametro2.Value = fecha_corta;
            comando1.Parameters.Add(parametro2);

            MySqlParameter parametro3 = new MySqlParameter();
            parametro3.ParameterName = "@id_asignacion";
            parametro3.Value = asignacion;
            comando1.Parameters.Add(parametro3);

            try
            {
                Conexion.Open();
                comando1.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "");
            }
        }
        private void RevisarAsistencias(int id_a)
        {
            fecha_dt = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comando2 = new MySqlCommand("SELECT DATE_FORMAT(fecha, '%d-%m-%Y') AS fecha, id_asignacion FROM registro_asistencias WHERE fecha = @fecha AND id_asignacion = @id_asignacion");
            comando2.Connection = Conexion;

            MySqlParameter parametro1 = new MySqlParameter();
            parametro1.ParameterName = "@fecha";
            parametro1.Value = fecha_dt;
            comando2.Parameters.Add(parametro1);

            MySqlParameter parametro2 = new MySqlParameter();
            parametro2.ParameterName = "@id_asignacion";
            parametro2.Value = id_a;
            comando2.Parameters.Add(parametro2);

            Conexion.Open();
            MySqlDataReader myreader = comando2.ExecuteReader();

            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    ra_fecha = myreader[0] + "";
                    ra_idasignacion = (int)myreader[1];
                }

            }
            else
            {

            }
            Conexion.Close();
        }
        private void RevisaRA(int id_a)
        {
            fecha_dt = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            if (ra_fecha == fecha_dt && ra_idasignacion == id_a)
            {
                if (perfil == 1 | perfil == 2)
                {
                    dateTimePicker1.Enabled = false;
                    dataGridView1.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;

                    MessageBox.Show("Ya has tomado asistencia para este grupo durante este día, si te equivocaste puedes modificar la asistencia en la opción correspondiente", "Advertencia");
                }
                else if (perfil == 0)
                {
                    dateTimePicker1.Enabled = false;
                    dataGridView1.Enabled = false;
                    label1.Enabled = false;
                    label2.Enabled = false;
                    label3.Enabled = false;
                    label4.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;

                    button3.Visible = false;

                    MessageBox.Show("Ya has tomado asistencia para este grupo durante este día, si te equivocaste puedes modificar la asistencia en la opción correspondiente", "Advertencia");
                }

            }
            else
            {
                if (perfil == 1 | perfil == 2)
                {
                    MostrarTabla();
                }
                else if (perfil == 0)
                {
                    AsignacionDeLoginAlPrograma();
                    MostrarTabla();
                }
            }
        }
        private void MuestraPrivilegios()
        {
            if (perfil == 1 | perfil == 2)
            {
                label3.Enabled = true;
                label4.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Enabled = true;

                label3.Visible = true;
                label4.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                button3.Visible = true;
            }
            else if (perfil == 0)
            {
                label3.Enabled = false;
                label4.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Enabled = false;
                button3.Visible = false;

                RevisarAsistencias(id_asignacion);
                RevisaRA(id_asignacion);
                AsignacionDeLoginAlPrograma();
                MostrarTabla();
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
        private void BloquearRegistro()
        {
            if (perfil == 1 | perfil == 2)
            {

            }
            else if (perfil == 0)
            {
                label3.Enabled = false;
                label4.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button3.Enabled = false;
            }
        }
    }
}
