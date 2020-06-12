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
    public partial class Consulta_G_alumno : Form
    {
        public Consulta_G_alumno()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();

        private void Consulta_G_alumno_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;

            MostrarTabla();
        }

        private void MostrarTabla() 
        {
            String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand("SELECT al.no_control, al.no_tarjeta, al.apellidos, al.nombre, a.grado, a.grupo, al.foto FROM alumnos al INNER JOIN asignacion a ON	al.id_asignacion = a.id_asignacion;");
            comandoconsulta.Connection = Conexion;
            MySqlDataAdapter con = new MySqlDataAdapter(comandoconsulta);
            DataSet Set = new DataSet();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;

            con.Fill(Set);

            dataGridView1.DataSource = Set.Tables[0];

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            con.Dispose();
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminaAlumnos();
        }

        private void EliminaAlumnos()
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                bool eliminar = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                string id = dataGridView1.Rows[i].Cells[1].Value.ToString();

                if (eliminar == true)
                {
                    DialogResult elim = MessageBox.Show("¿DESEAS ELIMINAR EL ALUMNO?", "ELIMINAR", MessageBoxButtons.YesNo);
                    if (elim == DialogResult.Yes)
                    {
                        DataGridViewRow filaEliminar = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(filaEliminar);

                        MySqlConnection Conexion = new MySqlConnection();
                        String CadenaConexion = "Server=localhost; User id=root; Database=boletas; Password=azr4510m;";
                        Conexion.ConnectionString = CadenaConexion;
                        try
                        {
                            Conexion.ConnectionString = CadenaConexion;
                            Conexion.Open();
                            string consulta = "delete from alumnos where no_control='" + id + "';";

                            MySqlCommand comando = new MySqlCommand();

                            comando.Connection = Conexion;

                            comando.CommandText = consulta;
                            MySqlDataReader leer = comando.ExecuteReader();
                            MessageBox.Show("ELIMINACION CORRECTA");

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ERROR NO SE PUEDO REALIZAR LA EMLIMINACION" + err);
                        }
                        Conexion.Close();
                    }
                }
            }
        }
    }
}
