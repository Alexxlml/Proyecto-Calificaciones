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
    public partial class Consulta_G_Usuario : Form
    {
        public Consulta_G_Usuario()
        {
            InitializeComponent();
        }

        MySqlConnection Conexion = new MySqlConnection();

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void Consulta_G_Usuario_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;

            ConsultaUsuarios();
        }

        private void ConsultaUsuarios() 
        {
            String query = "SELECT u.id_usuario, u.nombre, a.grado, a.grupo, p.nombre_privilegios FROM usuarios u INNER JOIN asignacion a ON u.id_asignacion = a.id_asignacion INNER JOIN privilegios p ON u.tipo_usuario = p.id_privilegios;";

            String CadenaConexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
            Conexion.ConnectionString = CadenaConexion;

            MySqlCommand comandoconsulta = new MySqlCommand(query);
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminaUsuarios();
        }

        private void EliminaUsuarios() 
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                bool eliminar = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);
                string id = dataGridView1.Rows[i].Cells[1].Value.ToString();

                if (eliminar == true)
                {
                    DialogResult elim = MessageBox.Show("¿DESEAS ELIMINAR EL USUARIO?", "ELIMINAR", MessageBoxButtons.YesNo);
                    if (elim == DialogResult.Yes)
                    {
                        DataGridViewRow filaEliminar = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(filaEliminar);

                        MySqlConnection Conexion = new MySqlConnection();
                        String CadenaConexion = "Server=localhost; User=root; Database=boletas; Password=azr4510m";
                        Conexion.ConnectionString = CadenaConexion;
                        try
                        {
                            Conexion.ConnectionString = CadenaConexion;
                            Conexion.Open();
                            string consulta = "delete from usuarios where id_usuario='" + id + "';";

                            MySqlCommand comando = new MySqlCommand();

                            comando.Connection = Conexion;

                            comando.CommandText = consulta;
                            MySqlDataReader leer = comando.ExecuteReader();
                            MessageBox.Show("ELIMINACION CORRECTA");

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("ERROR NO SE PUEDO REALIZAR LA EMLIMINACION");
                        }
                        Conexion.Close();
                    }
                }
            }

            ConsultaUsuarios();
        }
    }
}
