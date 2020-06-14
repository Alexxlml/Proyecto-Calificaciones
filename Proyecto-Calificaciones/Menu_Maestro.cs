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

        public Menu_Maestro()
        {
            InitializeComponent();
        }

        public Menu_Maestro(string usr1, int perfil)
        {
            this.usr1 = usr1;
            this.perfil = perfil;
        }
    }
}
