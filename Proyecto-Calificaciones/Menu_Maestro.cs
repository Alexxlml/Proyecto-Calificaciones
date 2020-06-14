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
    public partial class Menu_Maestro : Form
    {
        private string usr1;
        private int perfil;
        private int id_asignacion;

        public Menu_Maestro(string usr1, int perfil, int id_asignacion)
        {
            this.usr1 = usr1;
            this.perfil = perfil;
            this.id_asignacion = id_asignacion;
            InitializeComponent();
        }

        private void Menu_Maestro_Load(object sender, EventArgs e)
        {

        }

        private void registrarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Asistencias A_Asistencias = new Alta_Asistencias(usr1, perfil, id_asignacion);
            A_Asistencias.MdiParent = this;
            A_Asistencias.Show();
        }

        private void consultarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Asistencias C_Asistencias = new Consulta_Asistencias(usr1, perfil, id_asignacion);
            C_Asistencias.MdiParent = this;
            C_Asistencias.Show();
        }

        private void regsitrarCalificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Calificaciones A_Calificaciones = new Alta_Calificaciones(usr1,perfil,id_asignacion);
            A_Calificaciones.MdiParent = this;
            A_Calificaciones.Show();
        }

        private void consultarCalificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_G_Calificaciones C_G_Calificaciones = new Consulta_G_Calificaciones();
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
