using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Calificaciones
{
    public partial class Menu_Admin : Form
    {
        private string usr1;
        private int perfil;
        private int id_asignacion;

        public Menu_Admin(string usr1, int perfil, int id_asignacion)
        {
            this.usr1 = usr1;
            this.perfil = perfil;
            this.id_asignacion = id_asignacion;
            InitializeComponent();
        }

        private void Menu_Admin_Load(object sender, EventArgs e)
        {

        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Usuario Alta = new Alta_Usuario();
            Alta.MdiParent = this;
            Alta.Show();
        }

        private void consultarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_G_Usuario C_G_Usuario = new Consulta_G_Usuario();
            C_G_Usuario.MdiParent = this;
            C_G_Usuario.Show();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_I_Usuario C_I_Usuario = new Consulta_I_Usuario();
            C_I_Usuario.MdiParent = this;
            C_I_Usuario.Show();
        }

        private void registrarAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Alumno A_Alumno = new Alta_Alumno();
            A_Alumno.MdiParent = this;
            A_Alumno.Show();
        }

        private void consultarAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_G_alumno C_G_Alumno = new Consulta_G_alumno();
            C_G_Alumno.MdiParent = this;
            C_G_Alumno.Show();
        }

        private void modificarDatosDelAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_I_Alumno C_I_Alumno = new Consulta_I_Alumno();
            C_I_Alumno.MdiParent = this;
            C_I_Alumno.Show();
        }

        private void registrarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Asistencias A_Asistencias = new Alta_Asistencias(usr1, perfil, id_asignacion);
            A_Asistencias.MdiParent = this;
            A_Asistencias.Show();
        }

        private void consultarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Asistencias C_Asistencias = new Consulta_Asistencias(usr1,perfil,id_asignacion);
            C_Asistencias.MdiParent = this;
            C_Asistencias.Show();
        }

        private void justificarInasistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Justificar J = new Justificar();
            J.MdiParent = this;
            J.Show();
        }

        private void regsitrarCalificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Calificaciones A_Calificaciones = new Alta_Calificaciones(usr1,perfil,id_asignacion);
            A_Calificaciones.MdiParent = this;
            A_Calificaciones.Show();
        }

        private void consultarCalificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_G_Calificaciones C_G_Calificaciones = new Consulta_G_Calificaciones(usr1,perfil,id_asignacion);
            C_G_Calificaciones.MdiParent = this;
            C_G_Calificaciones.Show();
        }

        private void consultarKardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kardex kardex = new Kardex();
            kardex.MdiParent = this;
            kardex.Show();
        }
    }
}
