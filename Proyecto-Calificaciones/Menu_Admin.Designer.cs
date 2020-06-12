namespace Proyecto_Calificaciones
{
    partial class Menu_Admin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarDatosDelAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regsitrarCalificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarCalificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarKardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.justificarInasistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.asistenciasToolStripMenuItem,
            this.calificacionesToolStripMenuItem,
            this.kardexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.consultarUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.agregarUsuarioToolStripMenuItem.Text = "Registrar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // consultarUsuarioToolStripMenuItem
            // 
            this.consultarUsuarioToolStripMenuItem.Name = "consultarUsuarioToolStripMenuItem";
            this.consultarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.consultarUsuarioToolStripMenuItem.Text = "Consultar Usuario";
            this.consultarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.consultarUsuarioToolStripMenuItem_Click);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.modificarUsuarioToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAlumnoToolStripMenuItem,
            this.consultarAlumnosToolStripMenuItem,
            this.modificarDatosDelAlumnoToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // registrarAlumnoToolStripMenuItem
            // 
            this.registrarAlumnoToolStripMenuItem.Name = "registrarAlumnoToolStripMenuItem";
            this.registrarAlumnoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.registrarAlumnoToolStripMenuItem.Text = "Registrar Alumno";
            this.registrarAlumnoToolStripMenuItem.Click += new System.EventHandler(this.registrarAlumnoToolStripMenuItem_Click);
            // 
            // consultarAlumnosToolStripMenuItem
            // 
            this.consultarAlumnosToolStripMenuItem.Name = "consultarAlumnosToolStripMenuItem";
            this.consultarAlumnosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.consultarAlumnosToolStripMenuItem.Text = "Consultar Alumnos";
            this.consultarAlumnosToolStripMenuItem.Click += new System.EventHandler(this.consultarAlumnosToolStripMenuItem_Click);
            // 
            // modificarDatosDelAlumnoToolStripMenuItem
            // 
            this.modificarDatosDelAlumnoToolStripMenuItem.Name = "modificarDatosDelAlumnoToolStripMenuItem";
            this.modificarDatosDelAlumnoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.modificarDatosDelAlumnoToolStripMenuItem.Text = "Modificar Datos del Alumno";
            this.modificarDatosDelAlumnoToolStripMenuItem.Click += new System.EventHandler(this.modificarDatosDelAlumnoToolStripMenuItem_Click);
            // 
            // asistenciasToolStripMenuItem
            // 
            this.asistenciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAsistenciaToolStripMenuItem,
            this.consultarAsistenciaToolStripMenuItem,
            this.justificarInasistenciaToolStripMenuItem});
            this.asistenciasToolStripMenuItem.Name = "asistenciasToolStripMenuItem";
            this.asistenciasToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.asistenciasToolStripMenuItem.Text = "Asistencia";
            // 
            // registrarAsistenciaToolStripMenuItem
            // 
            this.registrarAsistenciaToolStripMenuItem.Name = "registrarAsistenciaToolStripMenuItem";
            this.registrarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.registrarAsistenciaToolStripMenuItem.Text = "Registrar Asistencia";
            this.registrarAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.registrarAsistenciaToolStripMenuItem_Click);
            // 
            // consultarAsistenciaToolStripMenuItem
            // 
            this.consultarAsistenciaToolStripMenuItem.Name = "consultarAsistenciaToolStripMenuItem";
            this.consultarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.consultarAsistenciaToolStripMenuItem.Text = "Consultar Asistencia";
            this.consultarAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.consultarAsistenciaToolStripMenuItem_Click);
            // 
            // calificacionesToolStripMenuItem
            // 
            this.calificacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regsitrarCalificacionesToolStripMenuItem,
            this.consultarCalificacionesToolStripMenuItem});
            this.calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            this.calificacionesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.calificacionesToolStripMenuItem.Text = "Calificaciones";
            // 
            // regsitrarCalificacionesToolStripMenuItem
            // 
            this.regsitrarCalificacionesToolStripMenuItem.Name = "regsitrarCalificacionesToolStripMenuItem";
            this.regsitrarCalificacionesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.regsitrarCalificacionesToolStripMenuItem.Text = "Regsitrar Calificaciones";
            this.regsitrarCalificacionesToolStripMenuItem.Click += new System.EventHandler(this.regsitrarCalificacionesToolStripMenuItem_Click);
            // 
            // consultarCalificacionesToolStripMenuItem
            // 
            this.consultarCalificacionesToolStripMenuItem.Name = "consultarCalificacionesToolStripMenuItem";
            this.consultarCalificacionesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.consultarCalificacionesToolStripMenuItem.Text = "Consultar Calificaciones";
            this.consultarCalificacionesToolStripMenuItem.Click += new System.EventHandler(this.consultarCalificacionesToolStripMenuItem_Click);
            // 
            // kardexToolStripMenuItem
            // 
            this.kardexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarKardexToolStripMenuItem});
            this.kardexToolStripMenuItem.Name = "kardexToolStripMenuItem";
            this.kardexToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.kardexToolStripMenuItem.Text = "Kardex";
            // 
            // consultarKardexToolStripMenuItem
            // 
            this.consultarKardexToolStripMenuItem.Name = "consultarKardexToolStripMenuItem";
            this.consultarKardexToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultarKardexToolStripMenuItem.Text = "Consultar Kardex";
            this.consultarKardexToolStripMenuItem.Click += new System.EventHandler(this.consultarKardexToolStripMenuItem_Click);
            // 
            // justificarInasistenciaToolStripMenuItem
            // 
            this.justificarInasistenciaToolStripMenuItem.Name = "justificarInasistenciaToolStripMenuItem";
            this.justificarInasistenciaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.justificarInasistenciaToolStripMenuItem.Text = "Modificar Inasistencia";
            this.justificarInasistenciaToolStripMenuItem.Click += new System.EventHandler(this.justificarInasistenciaToolStripMenuItem_Click);
            // 
            // Menu_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Menu_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Menu_Admin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarDatosDelAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asistenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regsitrarCalificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarCalificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kardexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarKardexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem justificarInasistenciaToolStripMenuItem;
    }
}

