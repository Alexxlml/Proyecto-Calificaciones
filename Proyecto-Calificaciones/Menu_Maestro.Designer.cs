namespace Proyecto_Calificaciones
{
    partial class Menu_Maestro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regsitrarCalificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarCalificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistenciasToolStripMenuItem,
            this.calificacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asistenciasToolStripMenuItem
            // 
            this.asistenciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarAsistenciaToolStripMenuItem,
            this.consultarAsistenciaToolStripMenuItem});
            this.asistenciasToolStripMenuItem.Name = "asistenciasToolStripMenuItem";
            this.asistenciasToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.asistenciasToolStripMenuItem.Text = "Asistencia";
            // 
            // registrarAsistenciaToolStripMenuItem
            // 
            this.registrarAsistenciaToolStripMenuItem.Name = "registrarAsistenciaToolStripMenuItem";
            this.registrarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.registrarAsistenciaToolStripMenuItem.Text = "Registrar Asistencia";
            this.registrarAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.registrarAsistenciaToolStripMenuItem_Click);
            // 
            // consultarAsistenciaToolStripMenuItem
            // 
            this.consultarAsistenciaToolStripMenuItem.Name = "consultarAsistenciaToolStripMenuItem";
            this.consultarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
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
            // Menu_Maestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Menu_Maestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Menu_Maestro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asistenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regsitrarCalificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarCalificacionesToolStripMenuItem;
    }
}