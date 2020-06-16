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
    public partial class Justificar : Form
    {
        public Justificar()
        {
            InitializeComponent();
        }
        string no_control, asistencia, justificacion, fecha, fecha_completa;
        bool bandera_modifica = false;
        MySqlConnection Conexion = new MySqlConnection();

        private void Justificar_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            dateTimePicker1.Value = DateTime.Now;

            ConsultaGeneral();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarTodos();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            ModificarAsistencias();
        }

        private void ConsultaGeneral()
        {
            fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            String CadenaConexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("SELECT al.no_control, CONCAT(al.apellidos,' ',al.nombre) as nombre, a.grado, a.grupo, asis.asistencia, asis.asistencia_justificada, asis.fecha, al.foto " +
                "FROM alumnos al " +
                "INNER JOIN asignacion a " +
                "ON	al.id_asignacion = a.id_asignacion " +
                "INNER JOIN asistencias asis " +
                "ON al.no_control = asis.no_control " +
                "WHERE asis.fecha like '" + fecha + "%';");

            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView1.DataSource = Set.Tables[0];

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            con.Dispose();
        }
        private void SeleccionarTodos()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }
        private void ModificarAsistencias()
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    bandera_modifica = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                    no_control = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    asistencia = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    justificacion = dataGridView1.Rows[i].Cells[6].Value.ToString();

                    if (bandera_modifica == true)
                    {
                        String pre_fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        fecha = pre_fecha + "%";
                        fecha_completa = dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss");

                        MessageBox.Show(no_control + " " + asistencia + " " + justificacion + " " + fecha_completa);


                        MySqlCommand comando1 = new MySqlCommand("UPDATE asistencias SET asistencia = @asistencia, asistencia_justificada = @asistencia_justificada, fecha = @fecha1 " +
                            "WHERE no_control = @no_control AND fecha like @fecha2;");
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
                        parametro3.Value = justificacion;
                        comando1.Parameters.Add(parametro3);

                        MySqlParameter parametro4 = new MySqlParameter();
                        parametro4.ParameterName = "@fecha1";
                        parametro4.Value = fecha_completa;
                        comando1.Parameters.Add(parametro4);

                        MySqlParameter parametro5 = new MySqlParameter();
                        parametro5.ParameterName = "@fecha2";
                        parametro5.Value = fecha;
                        comando1.Parameters.Add(parametro5);

                        try
                        {
                            Conexion.Open();
                            comando1.ExecuteNonQuery();
                        }
                        catch(Exception err)
                        {
                            MessageBox.Show(err + "");
                        }
                        Conexion.Close();

                    }
                }
                MessageBox.Show("Asistencia modificada con éxito", "Modificar asistencia");
            }
            catch
            {
                MessageBox.Show("Hubo un error");
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            ConsultaGeneral();
        }
    }
}
